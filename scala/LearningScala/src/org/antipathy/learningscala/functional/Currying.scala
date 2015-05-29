package org.antipathy.learningscala.functional

/**
 * Created by ciaranke on 29/05/2015.
 */
object Currying extends App {

  /* A curried function is applied to multiple argument lists, instead of just one. */
  def curriedSum(x: Int)(y: Int) = x + y
  println(curriedSum(1)(2))

  /* can be used like a closure */
  val addTwo = curriedSum(2)_
  println(addTwo(3))

  /* i.e. it does the same thing as  */
  def first(x: Int) = (y: Int) => x + y
  val second = first(1)

}
