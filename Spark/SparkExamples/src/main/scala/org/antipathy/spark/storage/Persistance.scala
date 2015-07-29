package org.antipathy.spark.storage

import org.apache.spark.storage.StorageLevel
import org.apache.spark.{SparkConf, SparkContext}

/**
 * Created by fluffy on 28/07/15.
 */
object Persistance {

  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    val someList = sc.parallelize((for (x <- 1 to 1000) yield x).toList)

    val result = someList.map(x => x * x)
    result.persist(StorageLevel.MEMORY_AND_DISK_2)
    /**
     * DISK_ONLY:
     * DISK_ONLY_2:
     * MEMORY_AND_DISK:
     * MEMORY_AND_DISK_2:
     * MEMORY_AND_DISK_SER:
     * MEMORY_AND_DISK_SER_2:
     * MEMORY_ONLY:
     * MEMORY_ONLY_2:
     * MEMORY_ONLY_SER:
     * MEMORY_ONLY_SER_2:
     * NONE:
     * OFF_HEAP: needs tachyon
     */
    println("Count: " + result.count())
    println("Values: " + result.collect().mkString(","))

    /*
    * uses LRU when space is low.
    */
    result.unpersist()



  }


}
