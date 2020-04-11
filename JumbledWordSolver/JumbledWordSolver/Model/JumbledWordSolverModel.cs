﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JumbledWordSolver.Model
{
    public class JumbledWordSolverModel
    {
        //Write the properties here
        private string manualEntryValue;
        public string ManualEntryValue
        {
            get
            {
                return manualEntryValue;
            }
            set
            {
                manualEntryValue = value;
            }

        }

        private string inputFilePath;
        public string InputFilePath
        {
            get
            {
                return inputFilePath;
            }
            set
            {
                inputFilePath = value;
            }
        }

        private string displayUnscrambledWords;
        public string DisplayUnscrambledWords
        {
            get
            {
                return displayUnscrambledWords;
            }
            set
            {
                displayUnscrambledWords = value;
            }
        }

            private const string dictonaryLocation = @"..\..\Utility\EnglishDictionaryFiles\english2.txt";
            private static readonly FileReader _fileReader = new FileReader();
            private static readonly WordMatcher _wordMatcher = new WordMatcher();
          


        public void ExecuteScrambledWordManualEntryScenario()
            {
                string ManualInput = ManualEntryValue; //= for textbox;
                string[] scrambledWords = ManualInput.Split(',');
                DisplayMatchedScrambledWords(scrambledWords);
            }

            //TODO: same for file senario also  
       public void ExecuteScrambledWordFileEntryScenario()
            {
                string inputScrambledFile = InputFilePath;
                string[] scrambledWords = _fileReader.Read(inputScrambledFile);//get input form the file
                DisplayMatchedScrambledWords(scrambledWords);
            }

           public void DisplayMatchedScrambledWords(string[] scrambledWords)
            {
                string[] wordList = _fileReader.Read(dictonaryLocation);//= get from the file; //form the dictinory
                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);  //return the list of matched words

                if (matchedWords.Any())
                {
                    //show matched words
                    //matchedWords.scrambledWords  //gives scrambled words
                    //matchedWords.word // gives the matched words in respect to scrambled word

                    //For debuggin using the consol appliction checkModel

                    foreach (var matchedWord in matchedWords)
                    {
                        Console.WriteLine("\n{0} = {1}", matchedWord.scrambledWords, matchedWord.word);

                    }
                    Console.ReadLine();




                }
                else
                {
                    //nothing matched
                }
            }
    }
    class MatchedWord
    {
        public string scrambledWords { get; set; }
        public string word { get; set; }
    }
}