package org.antipathy.spark

import org.apache.hadoop.mapred.lib.HashPartitioner
import org.apache.spark
import org.apache.spark.storage.StorageLevel
import org.apache.spark.HashPartitioner
import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.rdd.{RDD, PairRDDFunctions}
import org.apache.spark.SparkContext._

import scala.reflect.ClassTag

/**
 * Created by fluffy on 28/07/15.
 */
object Partitioning {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)


    val one = sc.parallelize(List((1,"one"),(2,"two"),(3,"three"),(4,"four"),(5,"five")))
    val two = sc.parallelize(List((1,"one"),(2,"two"),(3,"three"),(6,"six"),(7,"seven")))

    //needs import org.apache.spark.SparkContext._
    //will save the RDD as three partitions
    one.intersection(two).partitionBy(new spark.HashPartitioner(3)).saveAsSequenceFile("./src/main/Resources/someFile.txt")

    val three = sc.sequenceFile[Int,String]("./src/main/Resources/someFile.txt")
    three.foreach(println)

  }
}
