package org.antipathy.learningscala.functional

import java.util


object Rational {

  def main(args: Array[String]) : Unit = {
    val oneHalf = new Rational(10,20)
    val twoThirds = new Rational(75,100)
    val whoKnows = new Rational(42,66)
    println("Result: " + (oneHalf + twoThirds + whoKnows))

    val ten20 = new Rational(10,20)
    val fifty100 = new Rational(50,100)
    println(ten20 + " equals " + fifty100 + " is " + (ten20 == fifty100))
  }

}

class Rational(numeratorIn: Int, denominatorIn: Int) {
  /* constructor */

  /* precondition for primary constructor, class will not be instantiated if false */
  /* throws an IllegalArgument exception */
  require(denominatorIn != 0)

  /* auxiliary constructor */
  def this(numeratorIn : Int) = this(numeratorIn, 1) /* this must be the first statement (like super) */
  /* can't actually call super here, must be in primary constructor */

  /* if calling another constructor, the callee must appear above the caller */
  def this(numeratorIn: String) = this(numeratorIn.toInt)

  /* required to access constructor
   args,  become fields */
  private val g = gcd(numeratorIn.abs, denominatorIn.abs)
  val numerator = numeratorIn / g
  val denominator = denominatorIn / g
  println("Created: " + this.toString())
  /* end constructor sort of */

  /* Rational operators */
  def * (that : Rational) : Rational = new Rational(numerator * that.numerator, denominator * that.denominator)
  def / (that :Rational) = new Rational (this.numerator * that.denominator, this.denominator * that.numerator)
  def + (that :Rational) : Rational = new Rational(numerator  * that.denominator + that.numerator * denominator,
    denominator * that.denominator)
  def - (that : Rational) = new Rational((this.numerator * that.denominator) - (that.numerator * this.denominator),
    this.denominator * that.denominator)

  def < (that : Rational) : Boolean = (this.numerator * that.denominator) < (that.numerator * this.denominator)
  def > (that : Rational) : Boolean = (this.numerator * that.denominator) > (that.numerator * this.denominator)

  /* Int Operators */
  def + (that : Int) : Rational = new Rational(this.numerator + that, this.denominator)
  def - (that : Int) : Rational = new Rational(this.numerator - that, this.denominator)
  def * (that : Int) : Rational = new Rational(this.numerator * that, this.denominator)
  def / (that : Int) : Rational = new Rational(this.numerator / that, this.denominator)


  // allows 2 * Rational by converting the int, needs to be in scope
  implicit def IntToRational(x: Int) = new Rational(x)

  def max (that : Rational) : Rational = if (this < that) that else this
  override def toString() : String = numerator + "/" + denominator

  def == (that :Rational) = this.numerator == that.numerator && this.denominator == that.denominator

  private def gcd (a: Int, b: Int) : Int = if (b == 0) a else gcd(b, a % b)
}
