package org.antipathy.spark.storage

import org.apache.spark.rdd.RDD
import org.apache.spark.{SparkConf, SparkContext}

object Serialisation {

  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    //get the spark context
    val sc = new SparkContext(conf)
    val lines = sc.textFile("./src/main/Resources/derby.log")
    val search = new SearchFunction("Linux")
    //val linesContainingLinux = search.getMatchesFunctionReference(lines)
    //val linesContainingLinux = search.getMatchesFieldReference(lines)
    val linesContainingLinux = search.getMatchesNoReference(lines)
    linesContainingLinux.saveAsTextFile("/home/fluffy/lines")
  }


}

class SearchFunction(val query : String) {
  def isMatch(string : String) = {
    string.contains(query)
  }


  /**
   * isMatch means this.isMatch: not serializable
   */
  def getMatchesFunctionReference(rdd : RDD[String]): RDD[String] = {
    rdd.filter(isMatch)
  }

  /**
   * query means this.query: not serializable
   */
  def getMatchesFieldReference(rdd : RDD[String]) : RDD[String] = {
    rdd.filter(x => x.contains(query))
  }

  /**
   * No references to this.
   */
  def getMatchesNoReference(rdd : RDD[String]) : RDD[String] = {
    val query_  = this.query
    rdd.filter(x => x.contains(query_))
  }


}
