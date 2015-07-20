package org.antipathy.learningscala.XML

//see the pom file, this is now a
//separate package
import scala.xml

object XMLLiterals extends App {
  //Scala lets you type in XML as a literal anywhere that an expression is valid.
  val xmlLit = <a>this is some XML <nested>with a nested tag</nested></a>
  println(xmlLit)

  //Class Node is the abstract superclass of all XML node classes.
  //Class Text is a node holding just text.

  /*
    Class NodeSeq holds a sequence of nodes. Many methods in the XML
    library process NodeSeqs in places you might expect them to process
    individual Nodes. You can still use such methods with individual
    nodes, however, since Node extends from NodeSeq. This may sound
    weird, but it works out well for XML. You can think of an individual
    Node as a one-element NodeSeq.
  */

  //You can evaluate Scala code in the middle of an XML literal
  //by using curly braces ({}) as an escape
  // two braces {{}} is the escape
  val lit2 = <a> { if ( 1920 < 2000) <old>{1920}</old> else xml.NodeSeq.Empty }</a>




}
