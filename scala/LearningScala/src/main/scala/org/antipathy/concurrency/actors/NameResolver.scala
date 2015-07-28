package org.antipathy.concurrency.actors

/**
 * Created by fluffy on 27/07/15.
 */
object NameResolver extends Actor {
  def act() {
    react {
      case (name: String, actor: Actor) =>
        actor ! getIp(name)
        act()
      case "EXIT" =>
        println("Name resolver exiting.")
      // quit
      case msg =>
        println("Unhandled message: "+ msg)
        act()
    }
  }
  def getIp(name: String): Option[InetAddress] = {
    try {
      Some(InetAddress.getByName(name))
    } catch {
      case _:UnknownHostException => None
    }
  }
}

object Main extends App {
  NameResolver.start()
  NameResolver ! ("www.scalalang.org", self)
  self.receiveWithin(0) { case x => x }
  NameResolver ! ("wwwwww.scalalang.org", self)
  self.receiveWithin(0) { case x => x }
}