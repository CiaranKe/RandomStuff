package org.antipathy.spark.IO

import org.apache.spark._
import com.fasterxml.jackson.module.scala.DefaultScalaModule
import com.fasterxml.jackson.module.scala.experimental.ScalaObjectMapper
import com.fasterxml.jackson.databind.ObjectMapper
import com.fasterxml.jackson.databind.DeserializationFeature
import org.apache.spark.rdd.RDD

/**
 <dependency>
	  <groupId>com.fasterxml.jackson.module</groupId>
	  <artifactId>jackson-module-scala_2.10</artifactId>
	  <version>2.6.0</version>
  </dependency>
  <dependency>
	  <groupId>com.fasterxml.jackson.core</groupId>
	  <artifactId>jackson-databind</artifactId>
	  <version>2.6.0</version>
  </dependency>
  *
  */


// Note: must be a top level class
case class Person(name: String, lovesPandas: Boolean) {
  override def toString = s"I'm $name and the rumors about my Panda fetish are $lovesPandas"
}

object JsonIO {

  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)
    /**
     * Assuming one record per row, the fasted way to load json is to read it as a text file and parse the
     * JSON
     */
    val input = sc.textFile("./src/main/resources/pandainfo.json")

    // Parse it into a specific case class. We use mapPartitions beacuse:
    // (a) ObjectMapper is not serializable so we either create a singleton object encapsulating ObjectMapper
    //     on the driver and have to send data back to the driver to go through the singleton object.
    //     Alternatively we can let each node create its own ObjectMapper but that's expensive in a map
    // (b) To solve for creating an ObjectMapper on each node without being too expensive we create one per
    //     partition with mapPartitions. Solves serialization and object creation performance hit.
    val result = input.mapPartitions(records => {
      // mapper object created on each executor node
      val mapper = new ObjectMapper with ScalaObjectMapper
      mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false)
      mapper.registerModule(DefaultScalaModule)
      // We use flatMap to handle errors
      // by returning an empty list (None) if we encounter an issue and a
      // list with one element if everything is ok (Some(_)).
      records.flatMap(record => {
        try {
          Some(mapper.readValue(record, classOf[Person]))
        } catch {
          case e: Exception => None
        }
      })
    }, true)
    result.foreach(println)


    /* Save the Pandas!!!! */
    result.filter(_.lovesPandas).map{ record =>
      val mapper = new ObjectMapper with ScalaObjectMapper
      mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false)
      mapper.registerModule(DefaultScalaModule)
      mapper.writeValueAsString(record)
    }.saveAsTextFile("./src/main/resources/peopleWhoLovePandas.json")
  }
}
