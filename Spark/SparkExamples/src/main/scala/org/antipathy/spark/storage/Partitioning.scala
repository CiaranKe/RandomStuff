package org.antipathy.spark.storage

import org.apache.spark
import org.apache.spark.SparkContext._
import org.apache.spark.{Partitioner, SparkConf, SparkContext}

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

    //View how many partitions an RDD has.
    val partitions = if (one.partitioner.isDefined) {
      one.partitioner.get.numPartitions.toString
    } else {
      "Not defined"
    }
    println(partitions)

    /* mapValues preserves partitioning */
  }
}

object DNPartRunner {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    //val urls = sc.textFile("someURLFile").partitionBy(new DomainNamePartitioner(10)).persist()
  }
}

class DomainNamePartitioner(numParts : Int) extends Partitioner {

  override def numPartitions: Int = numParts
  override def getPartition(key: Any): Int = {
    val domain = new java.net.URL(key.toString).getHost
    val code = (domain.hashCode % numPartitions)
    if (code < 0) {
      code + numPartitions
    } else {
      code
    }
  }
  override def equals(other : Any) : Boolean = other match {
    case dnp : DomainNamePartitioner => dnp.numPartitions == numPartitions
    case _ => false
  }
}