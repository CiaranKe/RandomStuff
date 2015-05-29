package org.antipathy.learningscala.functional

/**
 * Created by ciaranke on 28/05/2015.
 */
object TailRecursion {

  def isGoodEnough(d: Double): Boolean = d == 1.0

  def improve(d: Double): Double = d - 1

  def approximate(guess: Double) : Double = {
    if (isGoodEnough(guess)) guess
    else(approximate(improve(guess)))
  }

  def approximateLoop(initialGuess: Double): Double = {
    var guess = initialGuess
    while (!isGoodEnough(guess))
      guess = improve(guess)
    guess
  }

  def timedExample = {
    val guess = 100000.0D

    val startTime1 = System.currentTimeMillis()
    approximate(guess)
    val endTime1  = System.currentTimeMillis()

    val startTime2  = System.currentTimeMillis()
    approximateLoop(guess)
    val endTime2 = System.currentTimeMillis()

    /* Time should be almost identical
    * scala optimises the recursion to a loop in byte code
    */
    println("Recursion: " + ((endTime1 - startTime1)))
    println("Loop: " + ((endTime2 - startTime2)))
  }

  def exceptionExample (x : Int, tailRecursive : Boolean = false) : Int = {
    if (x == 0) throw new Exception("Oh oh!")
    else {
      if (tailRecursive) exceptionExample(x - 1)
      else exceptionExample(x - 1) + 1
    }
  }

  def main (args : Array[String]) : Unit = {

    //Note the differences in the stack traces
    //tail recursion
    try {exceptionExample(10, tailRecursive = true)} catch {
      case ex  => ex.printStackTrace
    }
    // no tail recursion
    try {exceptionExample(10)} catch {
      case ex  => ex.printStackTrace
    }

    /* optimisation can be switched off by passing
     * -g:notailcalls
     * to the scala compiler
     */

  }


}
