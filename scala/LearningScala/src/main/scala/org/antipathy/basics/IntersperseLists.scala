package org.antipathy.basics

object IntersperseLists {

  def main(args: Array[String]) {
    val numList = List[String](1.toString,2.toString,3.toString)
    val letterList = List[String]("A","B","C")
    println(intersperse[String](numList, letterList.toList))
  }

  /** Combine two lists in a A,1,B,2,C,3 pattern
    * @param listOne the first list
    * @param listTwo the sceond list
    * @tparam A the type of the list items
    * @return an interspersed list
    */
  def intersperse[A](listOne:List[A], listTwo:List[A]) : List[A] = { listOne match {
      case first :: rest => first :: intersperse(listTwo, rest)
      case _ => listTwo
    }
  }
}
