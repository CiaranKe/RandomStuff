package org.antipathy.concurrency.futures

import scala.concurrent.future
import scala.concurrent.Future
import scala.concurrent.ExecutionContext.Implicits.global
import scala.concurrent.duration._
import scala.util.Random

/*
  Scala’s Future[T], residing in the scala.concurrent package,
  is a container type, representing a computation that is supposed
  to eventually result in a value of type T. though, the computation
  might go wrong or time out, so when the future is completed,
  it may not have been successful after all, in which case it contains
  an exception instead.

  Future is a write-once container – after a future has been completed,
  it is effectively immutable. Also, the Future type only provides an
  interface for reading the value to be computed. The task of writing
  the computed value is achieved via a Promise.

 */
object FutureCode {

  type CoffeeBeans = String
  type GroundCoffee = String
  case class Water(temperature: Int)
  type Milk = String
  type FrothedMilk = String
  type Espresso = String
  type Cappuccino = String


  /*
    object Future {
      def apply[T](body: => T)(implicit execctx: ExecutionContext): Future[T]
    }

    The computation to be computed asynchronously is passed in as the body
    by-name parameter. The second argument, in its own argument list, is an
    implicit one, which means we don’t have to specify one if a matching implicit
    value is defined somewhere in scope. We make sure this is the case by importing
    the global execution context.

    import scala.concurrent.ExecutionContext.Implicits.global

   */

  case class GrindingException(msg: String) extends Exception(msg)

  def grind(beans: CoffeeBeans): Future[GroundCoffee] = Future {
    println("start grinding...")
    Thread.sleep(Random.nextInt(2000))
    if (beans == "baked beans") throw GrindingException("are you joking?")
    println("finished grinding...")
    s"ground coffee of $beans"
  }

  def heatWater(water: Water): Future[Water] = Future {
    println("heating the water now")
    Thread.sleep(Random.nextInt(2000))
    println("hot, it's hot!")
    water.copy(temperature = 85)
  }

  def frothMilk(milk: Milk): Future[FrothedMilk] = Future {
    println("milk frothing system engaged!")
    Thread.sleep(Random.nextInt(2000))
    println("shutting down milk frothing system")
    s"frothed $milk"
  }

  def brew(coffee: GroundCoffee, heatedWater: Water): Future[Espresso] = Future {
    println("happy brewing :)")
    Thread.sleep(Random.nextInt(2000))
    println("it's brewed!")
    "espresso"
  }

  def main(args: Array[String]) {
    /* Callbacks for futures are partial functions. You can pass a callback to the onSuccess method.
     *  It will only be called if the Future completes successfully.  A better option is
      * to use the onComplete partial function
     */
    import scala.util.{Success, Failure}

    grind("Arabica beans").onComplete {
      case Success(ground) => println("Ok, I have coffee")
      case Failure(ex) => println("Nooooooooooooooooooooooooo!")
    }

    /* the function passed to map will be executed if the future completes successfully */
    val tempOK = heatWater(Water(25)).map { water =>
      println("Heated water")
      (80 to 85).contains(water.temperature)
    }


  }
}
