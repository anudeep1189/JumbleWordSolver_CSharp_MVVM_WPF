using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JumbledWordSolver.Model;
using System.Collections.Generic;

namespace UnitTestJumbledWordSolver
{
    [TestClass]
    public class TestJumbledWordTest
    {
        //WordMatcher class object
        private readonly WordMatcher _WordMatcher = new WordMatcher();
        private List<MatchedWord> matchWord;

        //single word matcher unit testing
        [TestMethod]
        public void TestJumbledWordSingleWordMatch()
        {
            string[] words = { "act", "tom", "tyh" };
            string[] scrambledWord = {"tac"};
            matchWord = _WordMatcher.Match(scrambledWord,words);

            Assert.IsTrue(matchWord.Count == 1);
            Assert.IsTrue(matchWord[0].scrambledWords.Equals("tac"));
            Assert.IsTrue(matchWord[0].word.Equals("act"));

        }

        //multi word matcher unit testing
        [TestMethod]
        public void TestJumbledWordMultiWordMatch()
        {
            string[] words = { "act", "ccc", "tyh","ddd","den" };
            string[] scrambledWord = { "tac","nde" };
            matchWord = _WordMatcher.Match(scrambledWord, words);

            Assert.IsTrue(matchWord.Count == 2);

            Assert.IsTrue(matchWord[0].scrambledWords.Equals("tac"));
            Assert.IsTrue(matchWord[0].word.Equals("act"));

            Assert.IsTrue(matchWord[1].scrambledWords.Equals("nde"));
            Assert.IsTrue(matchWord[1].word.Equals("den"));

        }


    }
}
