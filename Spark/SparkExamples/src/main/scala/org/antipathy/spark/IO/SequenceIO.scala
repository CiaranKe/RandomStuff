package org.antipathy.spark.IO

import org.apache.spark.{SparkContext, SparkConf}
import org.apache.hadoop.io.Text
import org.apache.hadoop.io.IntWritable
import org.apache.spark.SparkContext._

/**
 * Sequence files are a Hadoop format composed of flat files with KeyValue pairs
 *
 */
object SequenceIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /* Read the values as MR Writables */
    val seqData = sc.sequenceFile("./src/main/Resources/pandaInfo.seq", classOf[Text], classOf[IntWritable]).
      /* map to required types */
      map{
        case(text, intW) => (text.toString, intW.get())
      }

    seqData.foreach(println)

     /* Save a sequenceFile */
    seqData.saveAsSequenceFile("./src/main/Resources/pandaInfoTemp")
  }
}
