package org.antipathy.spark.IO

import java.sql.{ResultSet, DriverManager}

import org.apache.spark.rdd.JdbcRDD
import org.apache.spark.{SparkContext, SparkConf}

case class User(id: Int, username : String, email: String, dateSince: String){
  override def toString = s"ID: $id, USER: $username, EMAIL: $email, DATE: $dateSince"
}

object DBIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /*
    * lowerbound: which row to start compute with
    * upperbound: how many rows to read.
    *
    * Can't find any way to avoid using these,
    */
    val users = new JdbcRDD[User](sc, createConnection, "Select * from Users where id >= ? and id <= ?;",
      lowerBound = 0, upperBound = 1000000, numPartitions = 1, mapRow = extractUserValues)
    users.collect().foreach(println)
  }

  def createConnection() = {
    Class.forName("com.mysql.jdbc.Driver").newInstance()
    DriverManager.getConnection("jdbc:mysql://localhost/SparkSQL?user=root&password=")
  }

  def extractUserValues(r : ResultSet) = {
    new User(r.getInt(1), r.getString(2), r.getString(3), r.getString(4))
  }
}
