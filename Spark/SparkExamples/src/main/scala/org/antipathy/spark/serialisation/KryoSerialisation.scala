package org.antipathy.spark.serialisation

import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.SparkContext._

/**
 * Created by fluffy on 30/07/15.
 */
object KryoSerialisation {

  def main(args: Array[String]): Unit = {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project").
    //set up kryo
    set("spark.serializer","org.apache.spark.serializer.KryoSerializer").
    set("spark.kryo.registrationRequired","true")
    //register the classes with kryo
    //conf.registerKryoClasses(Array(classOf[ClassOne], classOf[ClassTwo]))



    val sc = new SparkContext(conf)
    val lines = sc.textFile("/home/fluffy/Work/Personal/RandomStuff/Spark/SparkExamples/src/main/Resources/derby.log")

    println(s"found ${lines.count()} lines." )
    lines.persist()
    val words = lines.flatMap(line => line.split(" "))
    val counts = words.map(word => (word,1)).reduceByKey(_ + _)
    counts.saveAsTextFile("./src/main/Resources/wordcount")


  }
}
