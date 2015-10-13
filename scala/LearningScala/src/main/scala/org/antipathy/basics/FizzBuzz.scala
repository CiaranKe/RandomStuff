package org.antipathy.basics

import java.util.Scanner

object FizzBuzz extends App {

  println("Enter a number: ")
  (1 to new Scanner(System.in).nextInt()).foreach{ i =>
    println {
      if ((i % 3 == 0) && (i % 5 == 0)) {
        "FizzBuzz"
      } else if (i % 3 == 0) {
        "Fizz"
      } else if (i % 5 == 0) {
        "Buzz"
      } else {
        i
      }
    }
  }
}
