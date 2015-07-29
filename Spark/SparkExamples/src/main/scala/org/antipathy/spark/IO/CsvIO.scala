package org.antipathy.spark.IO

import java.io.{StringWriter, StringReader}

import com.fasterxml.jackson.module.scala.util.StringW
import org.apache.spark.rdd.RDD
import org.apache.spark.{SparkContext, SparkConf}
import au.com.bytecode.opencsv.{CSVWriter, CSVReader}
import scala.collection.JavaConversions._

/*
<dependency>
	<groupId>net.sf.opencsv</groupId>
	<artifactId>opencsv</artifactId>
	<version>2.3</version>
</dependency>
 */

object CsvIO {

  case class Person(name :String, favoriteAnimal: String)

  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)
    readCSVasTextFile(sc)
    val result = readCSVasWholefile(sc)
    saveCSV(sc,result)
  }

  /**
   * If there are no newlines in the csv
   */
  def readCSVasTextFile(sc: SparkContext) = {
    println("Reading CSV as text")
    val input = sc.textFile("./src/main/Resources/favourite_animals.csv")
    val result = input.map{ line =>
      val reader = new CSVReader(new StringReader(line))
      reader.readNext()
    }
    result.foreach(p => println(p(0) + ", " + p(1)))
    result
  }

  /**
   * If there are newlines in the CSV
   */
  def readCSVasWholefile(sc: SparkContext) : RDD[Person] = {
    println("Reading whole files")
    val input = sc.wholeTextFiles("./src/main/Resources/favourite_animals.csv")
    val result = input.flatMap{
      case (_, txt) => {
        val reader = new CSVReader(new StringReader(txt))
        val values = reader.readAll()
        values.map(x => Person(x(0), x(1)))
      }
    }
    result.foreach(p => println(p.name + ", " + p.favoriteAnimal))
    result
  }

  /**
   * Save a CSV file
   */
  def saveCSV(sc: SparkContext, rdd: RDD[Person]): Unit = {
    rdd.map(person => List(person.name, person.favoriteAnimal).toArray).
      mapPartitions{people =>
        val sw = new StringWriter()
        val csvWriter = new CSVWriter(sw)
        csvWriter.writeAll(people.toList)
        Iterator(sw.toString)
      }.
      saveAsTextFile("./src/main/Resources/csvOutput")
  }
}
