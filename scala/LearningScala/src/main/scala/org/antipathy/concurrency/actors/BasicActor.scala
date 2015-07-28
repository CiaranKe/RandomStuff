package org.antipathy.concurrency.actors

for ( i <- 1 to 5) {
    println("I'm acting TOO!")
    Thread.sleep(1000)
  }
}

object BasicActorCaller {

  def main (args: Array[String]) {
    BasicActor.start(); alternativeActor.start()
    MessageReceiverActor.start(); MessageSenderActor.start()
  }

}

  /*
 * An actor is a thread-like entity that has a mailbox for receiving messages.
 * To implement an actor, you subclass scala.actors.Actor and implement
 * the act method
 */
object BasicActor extends scala.actors.Actor {
  def act(): Unit = {
    for ( i <- 1 to 5) {
      println("I'm acting!")
      Thread.sleep(1000)

      /* Actor.self can be used to access the current thread */

    }
  }
}



