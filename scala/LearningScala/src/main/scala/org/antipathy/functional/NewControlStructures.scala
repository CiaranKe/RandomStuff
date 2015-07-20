package org.antipathy.learningscala.functional

import java.io.{PrintWriter, File}
import java.util.Date

/**
 * Created by ciaranke on 29/05/2015.
 */
object NewControlStructures extends App {
  /* function takes a double and returns a double */
  def twice(x: Double)(op: Double => Double) = op(op(x))
  println(twice(5){double => double + 1})

  /* Takes a file and applies the passed in function  (which takes a printwriter and
  returns a Unit */
  /* loan pattern */
  def withPrintWriter(file: File, op: PrintWriter => Unit) {
    val writer = new PrintWriter(file) /* This printwriter */
    try {
      op(writer)
    } finally {
      writer.close()
    }
  }

  withPrintWriter (
    new File("Date.txt"),
    writer => writer.println(new java.util.Date)
  )

  def withCurriedPrintWriter(file : File)(operation : PrintWriter => Unit) = {
    val writer = new PrintWriter(file)
    try {
      operation(writer)
    } finally {
      writer.close()
    }
  }
  withCurriedPrintWriter(new File("Date2.txt")) {
    writer => writer.println(new Date())
  }
}

object NamedParameters  extends App {
  var assertionsEnabled = true

  /* this works, but calling it is a bit crap */
  def myAssert(predicate: () => Boolean) =
    if (assertionsEnabled && !predicate())
      throw new AssertionError

  myAssert(() => 5 > 3) // needs () =>


  /* this works, but the boolean is calculated before it is passed */
  def boolAssert(predicate: Boolean) =
    if (assertionsEnabled && !predicate)
      throw new AssertionError

  boolAssert(5 > 3)

  /* this is what we're after */
  def byNameAssert(predicate: => Boolean) =
    if (assertionsEnabled && !predicate)
      throw new AssertionError
  byNameAssert(5 > 3)
}

