package org.antipathy.learningscala.basics

object helloArray extends App {
  val greet = new Array[String](3)
  greet(0) = "Hello"
  greet(1) = ", "
  greet(2) = "World!\n"
  for (i <- 0 to 2) {
    print(greet(i))
  }
}