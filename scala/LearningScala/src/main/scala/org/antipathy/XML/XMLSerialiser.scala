

object XMLSerialiser extends App {
  val therm = new CCTherm{
    val description = "hot dog"
    val yearMade = 1952
    val dateObtained = "14/03/2006"
    val bookPrice = 2199
    val condition = 9
    val someString = "something"
  }

  //get the text of an xml object
  therm.toXML.text

  //get an element from XML
  therm.toXML \ "description"

  //to get a element 'somewhere' in the xml
  therm.toXML \\ "description"

  //if not found, an empty Nodeseq is returned
  therm.toXML \\ "desciption"

  //get an attribute
  val year = therm.toXML \\ "@someString"
  val altyear = therm.toXML \ "condition"  \ "@someString"

  //convert to XML
  val node = therm.toXML
  //convert from XML
  val therm2 = CCTherm.fromXML(node)

  //save a file
  CCTherm.save("example.xml", therm.toXML)

  //load a file
  CCTherm.load("example.xml")

}
//catalog entry
abstract class CCTherm {

  val description : String
  val yearMade : Int
  val dateObtained : String
  val bookPrice : Int
  val condition : Int
  val someString: String
  //convert the class instance to XML
  def toXML = <cctherm>
        <description>{description}</description>
        <yearMade>{yearMade}</yearMade>
        <dateObtained>{dateObtained}</dateObtained>
        <bookPrice>{bookPrice}</bookPrice>
        <condition someString={someString} >{condition}</condition>
    </cctherm>
}

object CCTherm {
  def fromXML(node : scala.xml.Node): CCTherm =  new CCTherm {
    val description = (node \ "description").text
    val yearMade = (node \ "yearMade").text.toInt
    val dateObtained = (node \ "dateObtained").text
    val bookPrice = (node \ "bookPrice").text.toInt
    val condition = (node \ "condition").text.toInt
    val someString = (node \ "@someString").text
  }

  //save a file
  def save(fileName : String, node : scala.xml.Node) = scala.xml.XML.save(fileName, node)

  //load a file

  def load(fileName : String) = scala.xml.XML.loadFile(fileName)
}