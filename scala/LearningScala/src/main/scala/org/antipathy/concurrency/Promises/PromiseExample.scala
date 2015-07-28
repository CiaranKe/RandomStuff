package org.antipathy.concurrency.Promises

import scala.concurrent.{Future, Promise}
import scala.util.{Failure, Success}
import scala.concurrent.ExecutionContext.Implicits._



/**
 * Where Future provides an interface exclusively for querying, Promise is a companion type that
 * allows you to complete a Future by putting a value into it. This can be done exactly once. Once
 * a Promise has been completed, it’s not possible to change it any more.
 *
 * A Promise instance is always linked to exactly one instance of Future.
 */

object PromiseExample {
  case class TaxCut(reduction :Int)
  /*
  * either give the type as a type parameter to the factory method:
  * val taxcut = Promise[TaxCut]()
  * or give the compiler a hint by specifying the type of your val:
  */
  val taxCut : Promise[TaxCut] = Promise()

  /*
   * Once you have created a Promise, you can get the Future belonging to
   * it by calling the future method on the Promise instance:
   */
  val taxCutF = taxCut.future
  /*
   * The returned Future might not be the same object as the Promise, but calling the future method of a
   * Promise multiple times will definitely always return the same object to make sure the one-to-one
   * relationship between a Promise and its Future is preserved.
   */

  /*
   * To complete a Promise with a success, you call its success method, passing it the value that the Future
   * associated with it is supposed to have, once done, the promise is no longer writeable.
   */
  taxCut.success(TaxCut(20))

  /*
   * Also, completing your Promise like this leads to the successful completion of the associated Future.
   * Any success or completion handlers on that future will now be called, or if, for instance, you are
   * mapping that future, the mapping function will now be executed.
   *
   * Usually, the completion of the Promise and the processing of the completed Future will not happen
   * in the same thread. It’s more likely that you create your Promise, start computing its value in
   * another thread and immediately return the uncompleted Future to the caller.
   */

  def redeemCampaignPledge() : Future[TaxCut] = {
    val p : Promise[TaxCut] = Promise()
    Future {
      println("Starting new Government!")
      Thread.sleep(2000)
      p.success(TaxCut(20))
      println("Taxes cut! We demand re-election!")
    }
    p.future
  }

  val taxCutter : Future[TaxCut] = redeemCampaignPledge()
  println("Did they remember their promises?")
  taxCutter.onComplete{
    case Success(TaxCut(reduction)) => println(s"They cut taxes by $reduction WTF?!?!")
    case Failure(ex) => println(s"They broke it due to a ${ex.getMessage} ")
  }

}
