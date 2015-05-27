package org.antipathy.learningscala.basics

import scala.io.Source

object readLines extends App {
  /* Imperative */
  //if (args.length >0) {
  //	for (line <- Source.fromFile(args(0)).getLines()) {
  //		println(line.length + "| "+ line)
  //	}
  //}
  //else
  //Console.err.println("Please enter a filename")

  /* functional */
  Source.fromFile(args(0)).getLines().foreach(
    line => {
      println(line.length + "| "+ line)
    }
  )
}