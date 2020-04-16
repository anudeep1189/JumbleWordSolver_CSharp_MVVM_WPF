using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

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
          


        public List<MatchedWord> ExecuteScrambledWordManualEntryScenario()
            {
                string ManualInput = ManualEntryValue;
                string[] scrambledWords = ManualInput.Split(',');
                return DisplayMatchedScrambledWords(scrambledWords);
            }

            //TODO: same for file senario also  
       public List<MatchedWord> ExecuteScrambledWordFileEntryScenario()
            {
                string inputScrambledFile = InputFilePath;
                string[] scrambledWords = _fileReader.Read(inputScrambledFile);//get input form the file
                return DisplayMatchedScrambledWords(scrambledWords);
            }

        public List<MatchedWord> DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(dictonaryLocation);//= get from the file; //form the dictinory
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);  //return the list of matched words

            if (matchedWords.Count() == 0)
            {
                MessageBox.Show("No match Found");
            }

            return matchedWords;
        }
    }
    public class MatchedWord
    {
        public string scrambledWords { get; set; }
        public string word { get; set; }
    }
}