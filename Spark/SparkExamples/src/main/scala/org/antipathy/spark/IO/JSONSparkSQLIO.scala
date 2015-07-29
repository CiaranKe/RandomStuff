package org.antipathy.spark.IO

import org.apache.spark.sql.hive.HiveContext
import org.apache.spark.{SparkContext, SparkConf}

/**
 * Created by fluffy on 29/07/15.
 */
object JSONSparkSQLIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")

    /**
     * NO installation of Hive is required for this one.
     */
    val sc = new SparkContext(conf)
    val hc = new HiveContext(sc)

    val tweets = hc.jsonFile("./src/main/Resources/SampleTweet.json")
    tweets.registerTempTable("tweets")
    val result = hc.sql("SELECT * from tweets")
    result.foreach(println)
  }
}
