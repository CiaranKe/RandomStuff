package org.antipathy.spark.basics

import org.apache.spark.SparkContext._
import org.apache.spark._


object WordCount {
  def main(args: Array[String]): Unit = {
    //set the spark master to local
    val conf = new SparkConf().
    setMaster("local").
    setAppName("Example project")
    //get the spark context
    val sc = new SparkContext(conf)
    //get our text file and convert to RDD
    val lines = sc.textFile("/home/fluffy/Work/Personal/RandomStuff/Spark/SparkExamples/src/main/Resources/derby.log")
    /*
     * RDDs can also be created with sc.parallelise(List("something", something"))
     */
    println(s"found ${lines.count()} lines." )

    //persist a copy, we're going to use it a few times
    lines.cache()

    //count the lines
    val words = lines.flatMap(line => line.split(" "))
    val counts = words.map(word => (word,1)).reduceByKey(_ + _)
    //save as a text file
    counts.saveAsTextFile("./src/main/Resources/wordcount")

    //is Linux mentioned?
    lines.filter(_.contains("Linux")).
      flatMap(_.split(" ")).
      map((_,1)).
      reduceByKey(_ + _).saveAsTextFile("./src/main/Resources/LinuxCount")
  }
}
