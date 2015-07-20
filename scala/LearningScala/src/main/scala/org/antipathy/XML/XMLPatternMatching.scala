import scala.xml


/*
  An XML pattern looks just like an XML literal. The main difference is
  that if you insert a {} escape, then the code inside the {} is not an expression
  but a pattern. A pattern embedded in {} can use the full Scala pattern language,
  including binding new variables, performing type tests, and ignoring
  content using the _ and _* patterns
*/
object XMLPatternMatcher extends App {

  val a = <a>apple</a>
  val b = <b>banana</b>
  val c = <c>cherry</c>
  val nested = <a>I'm an <em>apple</em></a>

  def matchXML(node: scala.xml.Node) : String =
  node match {
      case <a>{contents}</a> => "It's an <a>: " + contents
      case <b>{contents}</b> => "It's a <b>: " + contents
      case <c>{contents}</c> => "It's a <c>: " + contents
      case _ => "Unknown type"
  }

  //The pattern for “anysequence” of XML nodes is written ‘_*’

  def matchNested(node: scala.xml.Node) : String =
  node match {
    case <a>{contents @ _*}</a> =>  "It's an <a>: " + contents
    case <b>{contents @ _*}</b> => "It's a <b>: " + contents
    case <c>{contents @ _*}</c> => "It's a <c>: " + contents
    case _ => "Unknown type"
  }

  println(matchXML(a))
  println(matchXML(b))
  println(matchXML(c))
  println(matchXML(nested))
  println(matchNested(nested))
}


object XMLPatternMatcher2 extends App {
  val catalog =
    <catalog>
      <cctherm>
        <description>hot dog #5</description>
        <yearMade>1952</yearMade>
        <dateObtained>March 14, 2006</dateObtained>
        <bookPrice>2199</bookPrice>
        <purchasePrice>500</purchasePrice>
        <condition>9</condition>
      </cctherm>
      <cctherm>
        <description>Sprite Boy</description>
        <yearMade>1964</yearMade>
        <dateObtained>April 28, 2003</dateObtained>
        <bookPrice>1695</bookPrice>
        <purchasePrice>595</purchasePrice>
        <condition>5</condition>
      </cctherm>
    </catalog>


  //counts whitespace as a node
  def process(node : scala.xml.Node) =
    node match {
      case <catalog>{therms @ _*}</catalog> =>
        for (therm <- therms)
          println("processing: " + (therm \ "description").text)
    }

  def processNoWhiteSpace(node : scala.xml.Node) =
    node match {
      case <catalog>{therms @ _*}</catalog> =>
        for (therm @ <cctherm>{_*}</cctherm> <- therms)
          println("processing: " + (therm \ "description").text)
    }

}