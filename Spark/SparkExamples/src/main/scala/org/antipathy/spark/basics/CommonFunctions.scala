package org.antipathy.spark.basics

import org.apache.spark.{SparkConf, SparkContext}
/**
 * Created by fluffy on 28/07/15.
 */
object CommonFunctions {
  def main(args: Array[String]) {
    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)


    /**
     * TRANSFORMATIONS
     */

    //squaring the values in an RDD
    val nums = sc.parallelize(List(1,2,3,4))
    val squared = nums.map(x => x * x)
    println(squared.collect().mkString(","))

    //splitting lines into words
    val input = List("Hello world", "this is spark", "splitting stuff")
    val words = sc.parallelize(input).flatMap(x => x.split(" "))
    //should print hello
    println(words.first())


    //set operations
    val one = sc.parallelize(List((1,"one"),(2,"two"),(3,"three"),(4,"four"),(5,"five")))
    val two = sc.parallelize(List((1,"one"),(2,"two"),(3,"three"),(6,"six"),(7,"seven")))

    //union
    println(one.union(two).collect().mkString(","))
    //distinct
    println(one.union(two).distinct().collect().mkString(","))
    //inner join
    println(one.intersection(two).collect().mkString(","))
    //left outer join
    println(one.subtract(two).collect().mkString(","))
    //right outer join
    println(two.subtract(one).collect().mkString(","))
    //cartesian product
    println(one.cartesian(two).collect().mkString(","))


    /**
     * ACTIONS
     */

    //reduce
    val toBeSummed = sc.parallelize(List(1,2,3,4,5,6,7,8,9,0))
    println("Sum: " + toBeSummed.reduce(_+_))

    //fold, similar to reduce, but takes a zeroth element
    println("Sum: " +toBeSummed.fold(0)((x,y) => x + y))

    //aggregate
    /* Like fold, supply an initial zero value of the type to return, then
     * supply a function to combine the elements and a second function to
     * merge the two accumulators, the first function runs on each partition
     * the second runs on the result of each partition's output
     */
    println(toBeSummed.aggregate(0)(((x,y) => x+y), ((x,y) => x+y)))

    //collect
    //returns the entire RDDs contents. try not to use this.

    //take
    println(toBeSummed.take(1))
    println(toBeSummed.top(1))

    /*
    * Other functions
    *
    * takeOrdered: take a number of elements specified by provided ordering
    * takeSample: return a number of elements at random
    * foreach: apply a supplied function (map) to each element in the RDD
    * count: count the elements
    * */

  }
}
