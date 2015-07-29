package org.antipathy.spark.IO

import org.apache.hadoop.io.{IntWritable, Text}
import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.SparkContext._

/**
 * Object files are a wrapper around sequenceFiles allowing us to just save the values.
 * They are useless once the classes change.
 */

object ObjectIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /* Read */
    val seqData = sc.objectFile("./src/main/Resources/pandaInfo.obj")
    seqData.foreach(println)
    /* write */
    seqData.saveAsObjectFile("./src/main/Resources/pandaInfo.tmp")
  }
}
