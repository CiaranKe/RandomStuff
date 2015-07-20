package org.antipathy.learningscala.functional

import java.io.FileNotFoundException

/**
 * Created by ciaranke on 27/05/2015.
 */
object TryCatch extends App{

  try {
    throw new RuntimeException
  } catch {
    case ex : FileNotFoundException => {println("Huh?")}
    case ex: RuntimeException => {println("Expected")}
    //case ex: Exception => {println("Everything else")}
    //without a catchall the exception is thrown
  } finally {
    println("Just like java")
  }

  /* if a finally clause includes an explicit return statement, or throws
    an exception, that return value or exception will “overrule” any previous one
    that originated in the try block or one of its catch clauses*/
  def one() : Int = try {1} finally {2}
  def two() : Int = try {return 1} finally {return 2}

  println(one)
  println(two)
}
