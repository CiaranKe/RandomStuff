package org.antipathy.learningscala.functional

/**
 * Created by ciaranke on 27/05/2015.
 */
object Match extends App{
  var firstArg = if (args.length >0 ) args(0) else ""

  firstArg match {
    case "Salt" => println("pepper")
    case "Chips" => println("Salsa")
    case "Eggs" => println("Bacon")
    case _ => println("huh?")
  }
  println("BlackMagic\n" * 2)
  firstArg = "Salt"
  println(firstArg match {
    case "Salt" => ("pepper")
    case "Chips" => ("Salsa")
    case "Eggs" => ("Bacon")
    case _ => ("huh?")
  })
}
