package org.antipathy.learningscala.basics

import ChecksumAccumulator._

object Summer {
	def main(args: Array[String]) {
		for (arg <- args) {
			Predef.println(arg + ": " + calculate(arg))
		}
	}
}