package org.antipathy.spark.AccumulatorsAndBroadcastVariables

import org.apache.spark.{SparkContext, SparkConf}
import org.apache.spark.SparkContext._

/**
 * Variables used inside the driver can be passed out to the executor,
 * But any updates to these variables are not passed back to the driver
 * and are lost.
 *
 * Accumulators provide a simple syntax for aggregating values from worker
 * nodes back to the driver.
 */
object AccumulatorLineCount {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /* create the accumulator */
    /* needs SparkContext._ */
    val invalidLine = sc.accumulator(0)
    val validLine = sc.accumulator(0)

    val data = sc.textFile("./src/main/Resources/flumeconf.cfg")

    val lines = data.map{ line =>
      if ("".equals(line)) {
        /* the accumulator is write only from here */
        invalidLine += 1
        ""
      } else {
        if (line.indexOf("=") != -1) {
          validLine += 1
          line
        } else ("")
      }
    }
    lines.saveAsTextFile("./src/main/Resources/lines.txt")
    /* this is still lazy so we won't see a value until an action is called */
    println(s"Found ${validLine.value} configuration properties")
    println(s"Found ${invalidLine.value} blank lines")

    /*
    *  Accumulators can only give an accurate (item) count on actions when in a foreach
    *  Due to speculative execution, accumulators cannot do so on a transformation.
    */

  }
}
