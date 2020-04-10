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
                    else
                    {
                        var scrambleWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambleWordArray);
                        Array.Sort(wordArray);
                        
                        //char array to string creation
                        var sortedScrambledWord = new string(scrambleWordArray);
                        var sortedwordArray = new string(wordArray);

                        if(sortedScrambledWord.Equals(sortedwordArray, StringComparison.OrdinalIgnoreCase))
                        {
                            matchWords.Add(BuildMatchedWord(scrambledWord, word));
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
