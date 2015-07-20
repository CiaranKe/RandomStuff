package org.antipathy.learningscala.functional

import java.io.File

/**
 * Created by ciaranke on 28/05/2015.
 */
class HighOrderFunctions /* functions that can take functions as args */ {

  def filesMatching(matcher:String => Boolean) = {
    val filesHere = (new File(".")).listFiles()
    for (file <- filesHere; if matcher(file.getName)) yield file
  }

  def filesEnding(query : String) = filesMatching(_.endsWith(query))
  def filesContaining(query : String) = filesMatching(_.contains(query))
  def filesRegex(query: String) = filesMatching(_.matches(query))
}

object HighOrderFunctions extends App {

  val highOrder = new HighOrderFunctions
  highOrder.filesContaining("a").foreach(println)
  highOrder.filesEnding("a").foreach(println)
  highOrder.filesRegex(".").foreach(println)
}
