package org.antipathy.spark.IO

import org.apache.spark.{SparkContext, SparkConf}

/**
 * Created by fluffy on 29/07/15.
 */
object TextIO {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /**
     * SPARK can read the following file formats 
     * Text
     * JSON
     * CSV
     * Sequence Files
     * Protocol Buffers
     * Object files : relies on serialisation, breaks if you change your classes.
     */

    /**
     * TEXT FILES
     */
    
    //read a file or diretory
    val text = sc.textFile("someTextFile")
    
    //in this instance the key is the name of the file
    val kvText = sc.wholeTextFiles("someDir")
    
    //save a text file
    kvText.saveAsTextFile("somedirectoryname")
  }
  
}
