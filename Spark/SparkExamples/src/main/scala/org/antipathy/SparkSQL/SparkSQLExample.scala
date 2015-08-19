package org.antipathy.SparkSQL

import org.apache.spark.sql.SQLContext
import org.apache.spark.sql.hive.HiveContext
import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.SparkContext._

/**
 * allows querying the data like SQL
 * both in app and via JDBC/OBDC
 *
 */

object SparkSQLExample {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)
    val hc = new HiveContext(sc)
    //can also use
    //val sqlSC = new SQLContext(sc)
    //for running without HQL support

    //required
    import hc._

    val input  = hc.jsonFile("./src/main/Resources/testweet.json")
    input.registerTempTable("points")

    //cache , this is the same as pandaPeople.cache()
    hc.cacheTable("points")

    //display the schema
    hc.sql("Select * from points").printSchema()

    //select from the schema using dot notation toplevel.nextlevel.bottomlevel
    val all = hc.sql("select user.id, user.name, user.screenName, user.followersCount from points").foreach(println)
  }
}
