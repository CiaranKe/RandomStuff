package org.antipathy.learningscala.basics

object functionalHello extends App {
  args.foreach((arg : String) => println("hello " + arg))
}