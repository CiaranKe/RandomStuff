package org.antipathy.learningscala.basics

object helloArg extends App {
  var i = 0
  while (i < args.length) {
    println("Hello " + args(i))
    i += 1
  }

}