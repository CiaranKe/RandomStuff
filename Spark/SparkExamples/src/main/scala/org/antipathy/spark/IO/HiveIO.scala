package org.antipathy.spark.IO

import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.sql.hive.HiveContext


/*
    <dependency>
        <groupId>org.apache.spark</groupId>
        <artifactId>spark-sql_2.10</artifactId>
        <version>1.2.1</version>
    </dependency>
    <dependency>
        <groupId>org.apache.spark</groupId>
        <artifactId>spark-hive_2.10</artifactId>
        <version>1.2.1</version>
    </dependency>
 */

/**
 * To use hive, the hive-site.xml must be copied to spark's /conf/ directory
 */


object HiveIO {
  val conf = new SparkConf().
    setMaster("local").
    setAppName("Example project")
  val sc = new SparkContext(conf)
  val hc = new HiveContext(sc)

  val users = hc.sql("SELECT id,username,role,dateCreated FROM USERS where someCondition=true")

}
