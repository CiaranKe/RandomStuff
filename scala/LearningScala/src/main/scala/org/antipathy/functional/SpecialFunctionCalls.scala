package org.antipathy.learningscala.functional

/**
 * Created by ciaranke on 28/05/2015.
 */
object SpecialFunctionCalls {

  //note the *, it allows mutlitple args to be passed to method
  def repeatedParameters(args: String*) = args.foreach(println)

  def repeatedParametersEx1 = repeatedParameters("First arg only"); repeatedParameters("First arg", "And a second", "and a third")

  def repeatedParametersEx2 {
    //pass a List
    val list = List("This", "is", "a", "List")
    //repeatedParameters(list) //fails
    //allows a list to be passed
    repeatedParameters(list : _*)
  }
  ///////////////////////////////////////////////////////////////////////////
  def namedArgs (distance : Int, time : Int) : Double =  distance / time
  def namedArgsEx1 = println(namedArgs(distance = 100, time = 50))
  //////////////////////////////////////////////////////////////////////////

  //define a default if no value specified
  def defaultArgs (out: java.io.PrintStream = Console.out, divisor : Int = 1) = out.println(System.currentTimeMillis() / divisor)

  def defaultArgsEx1 = {
    //no arg
    defaultArgs()
    //supplied arg
    defaultArgs(Console.err)
    //named second arg
    defaultArgs(divisor = 2)
  }


  def main (args: Array[String]) : Unit = {
    repeatedParametersEx1
    repeatedParametersEx2
    namedArgsEx1
    defaultArgsEx1
  }

}
