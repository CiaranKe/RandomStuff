package org.antipathy.spark

import org.apache.spark.api.java.StorageLevels
import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.rdd.PairRDDFunctions

/* if reduceByKey not showing */
import org.apache.spark.SparkContext._

/**
 * Created by fluffy on 28/07/15.
 */
object KVPairs {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    val input = sc.textFile("./src/main/Resources/lorumIpsom.txt")

    val linesWithKeys = input.map(x => (x.split(" ")(0),x))
    println("Old partitions: " + linesWithKeys.partitions.length)
    //increase the number of partitions
    linesWithKeys.repartition(10)
    //reduce the number of partitions
    linesWithKeys.coalesce(3)

    println("New partitions: " + linesWithKeys.partitions.length)
    linesWithKeys.persist(StorageLevels.MEMORY_ONLY_2)

    //get a count
    linesWithKeys.
      //get the line length for each KV pair
      map(line => (line._1,line._2.length)).
      //remove the duplicates
      reduceByKey((x,y)  => x + y).
      //sort the values
      sortBy (x => x._2,false,1).
      //print
      foreach(println)

    /* OR */

    //get a count, the 5 is setting the number of partitions
    linesWithKeys.mapValues{ x => x.length}.reduceByKey((x,y) => x + y,5).foreach(println)

    //filter out lines with more than 20 chars (should print nothing)
    linesWithKeys.filter(_._2.replace(" ", "").length < 20).foreach(println)

    /**
     * other functions
     *
     * keys(): rdd of just the keys
     * values(): rdd of just the values
     * sortByKey: sort the rdd by key
     * subtractByKey left/right outer join
     * join: inner join, if there are multiple keys of the same value, a pair is created for each possible combination
     * rightOuterJoin
     * leftOuterJoin
     * cogroup: group data from both keys sharing a join
     * countByKey
     * collectAsMap
     * lookup(keY): get all the values for a given key
     */
  }
}
