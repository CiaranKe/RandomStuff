package org.antipathy.learningscala.functional

/**
 * Created by ciaranke on 27/05/2015.
 */
object Closure {

  //define the function literal
  def makeAdder (toAdd : Int ) = (addTo : Int) => addTo + toAdd

  def example1 : Unit = {
    //create the function literal (partial function)
    val adder = makeAdder(2)
    //close (complete) the function literal and evaluate it
    val someInt = adder(20)
    println(someInt)
  }

  def makeIncreaser (increaseValue : Int ) = ( x : Int) => x + increaseValue

  def example2 : Unit = {
    var increaseValue = 5
    val increase = makeIncreaser(increaseValue)
    println(increase(5))
    increaseValue = 10
    val increase2 = makeIncreaser(increaseValue)
    println(increase2(5))
  }


  def main(args : Array[String]) : Unit = {
    example1
    example2

  }
}
