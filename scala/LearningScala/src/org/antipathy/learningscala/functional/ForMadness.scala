package org.antipathy.learningscala.functional

import java.io.File

/**
 * Created by ciaranke on 27/05/2015.
 */
object ForMadness extends App {

  /* imperative */
  val filesHere = (new File(".")).listFiles()
  for (file <- filesHere if file.getName.endsWith("iml")) {
    println(file)
  }

  
  /* functional*/
  (new File(".")).listFiles().filter(!_.isDirectory).filter(_.getName.endsWith("iml")).foreach(println)

  def fileLines (file : File) = scala.io.Source.fromFile(file).getLines().toList

  val forLineLengths =
    for {
      file <- filesHere
      if file.getName.endsWith(".iml")
      line <- fileLines(file)
      trimmed = line.trim
      if trimmed.contains("a")
    } yield trimmed.length

  println(forLineLengths)
}
