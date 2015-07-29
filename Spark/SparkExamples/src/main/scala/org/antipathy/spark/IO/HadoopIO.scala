package org.antipathy.spark.IO

import org.apache.hadoop.io.{IntWritable, Text}
import org.apache.hadoop.mapreduce.lib.input.SequenceFileInputFormat
import org.apache.hadoop.mapreduce.lib.output.SequenceFileOutputFormat
import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.SparkContext._
import org.apache.hadoop.io.{Text, IntWritable}

/**
 * Created by fluffy on 29/07/15.
 */
object HadoopIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /* read */
    val data = sc.newAPIHadoopFile[Text, IntWritable,SequenceFileInputFormat[Text, IntWritable]]("./src/main/Resources/pandaInfo.HadoopKVPair").
      map{case(text, intW) => (text.toString, intW.get)}

    data.foreach(println)

    /* Write */
    data.map { case (string, int) => (new Text(string), new IntWritable(int)) }.
      saveAsNewAPIHadoopFile[SequenceFileOutputFormat[Text, IntWritable]]("./src/main/Resources/pandaInfoHadoopTemp")
  }
}
