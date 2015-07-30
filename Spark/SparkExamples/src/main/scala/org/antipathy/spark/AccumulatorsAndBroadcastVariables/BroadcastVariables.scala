package org.antipathy.spark.AccumulatorsAndBroadcastVariables

import java.io.StringReader

import org.apache.spark.rdd.RDD
import org.apache.spark.{SparkContext, SparkConf}
import au.com.bytecode.opencsv.CSVReader
import org.apache.spark.SparkContext._

/**
 * Broadcast variables allow a large, readonly variable
 * to be passed to each of the worker nodes.
 */
object BroadcastVariables {

  case class Customer(id : Int, name : String)
  case class Order(id : Int, custId : Int, itemName: String)
  case class CustomerOrder(id : Int, customerName: String, itemName: String)

  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    /* A broadcast variable is simply an object of type org.apache.spark.broadcast.Broadcast[T]
     * which wraps around T */
    val customers = sc.broadcast(getCustomers(sc).collect())
    val orders = getOrders(sc)

    val customerOrders = orders.map { order =>
      CustomerOrder(order.id, getCustomerName(order.custId, customers.value), order.itemName)
    }
    customerOrders.foreach(println)

  }

  def getCustomerName(id : Int, customers: Array[Customer]): String = {
    for (customer <- customers) {if (customer.id == id) {return customer.name}}
    "Unknown"
  }

  def getCustomers(sc: SparkContext): RDD[Customer] = {
    sc.textFile("./src/main/Resources/CustomerOrders/Customers.txt").map { line =>
      val reader = new CSVReader(new StringReader(line))
      val lineData = reader.readNext()
      Customer(lineData(0).toInt, lineData(1))
    }
  }


  def getOrders(sc: SparkContext) : RDD[Order] = {
    sc.textFile("./src/main/Resources/CustomerOrders/Orders.txt").map { line =>
      val reader = new CSVReader(new StringReader(line))
      val lineData = reader.readNext()
      Order(lineData(0).toInt, lineData(1).toInt, lineData(2))
    }
  }
}
