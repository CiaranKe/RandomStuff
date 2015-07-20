package org.antipathy.learningscala.functional

class PassFunctionAsValue {

  def nestedFunction () = {
    def sum(a : Int, b : Int, c : Int ) = a + b + c

    // no args
    //val returnVal = sum _
    val returnVal = sum(1,( _ : Int ),3)
    returnVal
  }
}

object PassFunctionAsValue extends App {
  val example = new PassFunctionAsValue
  val function = example.nestedFunction()
  println(function(2))
  println(example.nestedFunction().apply(7))
}
