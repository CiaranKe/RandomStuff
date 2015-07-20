package org.antipathy.learningscala.basics

import org.antipathy.learningscala.basics.ChecksumAccumulator.calculate

object FallWinterSpringSummer extends App  /* Application outside intellij */{

  for (season <- List("Fall", "Winter", "Spring", "Summer")) {
    println(season + "" + calculate(season))
  }
}
