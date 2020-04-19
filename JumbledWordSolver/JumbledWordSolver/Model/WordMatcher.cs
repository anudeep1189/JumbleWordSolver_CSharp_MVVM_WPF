using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumbledWordSolver.Model
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchWords = new List<MatchedWord>();
        
            foreach (var scrambledWord in scrambledWords)
            {
                foreach(var word in wordList)
                {
                    if(scrambledWord.Equals(word,StringComparison.OrdinalIgnoreCase))
                    {
                        matchWords.Add(BuildMatchedWord(scrambledWord,word));
                    }

                    //if length of both word is same then proceed with this condition or else 
                    //dont wasting loop in checking the word.
                    else if(scrambledWord.Length == word.Length) 
                    {
                        var scrambleWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambleWordArray);
                        Array.Sort(wordArray);

                        //see if first letter of sorted scrambled word and word is same
                        //if not then no need to compare.
                        if (scrambleWordArray[0].ToString().Equals(wordArray[0].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            //char array to string creation
                            var sortedScrambledWord = new string(scrambleWordArray);
                            var sortedwordArray = new string(wordArray);

                            if (sortedScrambledWord.Equals(sortedwordArray, StringComparison.OrdinalIgnoreCase))
                            {
                                matchWords.Add(BuildMatchedWord(scrambledWord, word));
                            }  
                        }
                    }
                }
            }
            return matchWords;
        }

        private MatchedWord BuildMatchedWord(string scrambleWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord();
            matchedWord.scrambledWords = scrambleWord;
            matchedWord.word = word;
            //or
            //much more cleaner way to do 
            /*
            MatchedWord matchedWord = new MatchedWord
            {
                scrambledWords = scrambleWord;
                word = word;
            };
            */
            return matchedWord;
        }
    }
}
