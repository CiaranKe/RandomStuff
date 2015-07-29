package org.antipathy.spark.storage

import org.apache.spark.SparkContext._
import org.apache.spark.{HashPartitioner, SparkConf, SparkContext}


object PageRank {
  def main(args: Array[String]) {

    val conf = new SparkConf().
      setMaster("local").
      setAppName("Example project")
    val sc = new SparkContext(conf)

    val links = sc.objectFile[(String, Seq[String])]("").partitionBy(new HashPartitioner(100)).persist()

    //init each page's rank to one, since we use mapValues the partitioning will remain the same for ranks
    var ranks = links.mapValues{v => 1.0}

    //run 10 interations of PageRank
    for (i <- 0 until 10) {
      val contributions = links.join(ranks).flatMap {
        case (pageId, (links, rank)) => links.map(dest => (dest, rank / links.size))
      }
      ranks = contributions.reduceByKey((x,y) => x + y).mapValues(v => 0.15 + 0.85 * v)
    }
    //write out the final ranks
    ranks.saveAsTextFile("")
  }
}
