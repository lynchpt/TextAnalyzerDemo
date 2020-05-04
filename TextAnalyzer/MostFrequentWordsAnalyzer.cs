using System.Collections.Generic;

namespace TextAnalyzer
{
    /* This class makes a count of the occurrance of words of length >=4
     * in a text and reports on the n most frequent words, where n is an integer passed 
     * in to the constructor. 
     * Note only words of length > 4 are counted. Words are also "stopped" by removing
     * an 's' if it is the last character in the word before counting.This is because in
     * English and some other languages, the trailing letter s is a plural version of the 
     * same word, and we want to count the singular and plural versions as the same word. 
     * For example, in the text: "The hound was one of the hounds.",
     * The word "hound" is counted twice because "hounds" is counted as "hound"
     * (the word "hounds" is not counted seperately).
     * This class maintains a list of words that have been observed in the text along with
     * a count of the number of times that word has been observed.
     * The WordCount class may be used to keep track of the words that have been observed 
     * and their number of occurences in the lines of text.
     * 
    */


    public class MostFrequentWordsAnalyzer : TextAnalyzer
    {


        //TODO3: write the rest of this class. Declare any instance variables you need
        //       and implement the TextAnalyzer methods.
        //       Hint: You will need an ArrayList, an int, and a String Array

        private const int minWordLength = 5;
        private const string forbiddenTerminalLetter = "s";

        private List<WordCount> wordCountList = new List<WordCount>();
        private int topWordsCount;
        int finalResultsArrayLength = 0;
        private string[] resultData;

        /* Implement the constructor which takes an int parameter to initialize the number
         * of top words.
        */
        public MostFrequentWordsAnalyzer(int numTopWords) 
        {
            topWordsCount = numTopWords;
        }

        /** Implement analyzeData:
        *  This method processes the lines of test, where each line of text is processed
        *  in the following manner:
        *  1) It tokenizes the line of text by calling the String method split with this 
        *     argument:  line.split("[,.;:?!() ]")
        *     Each token is a "word", which is a String in the array returned from the call to split. 
        *  2) The token should be checked for an ending letter "s", which
        *     is removed if it exists.   
        *  3) After removing a trailing 's', the word length should be > 4. 
        *  4) The list of words that have been observed is checked to see if the current word 
        *     has been seen before. If so, its count is incremented. If not, the word is added to the
        *     list along with a count of 1.
        **/

        // Suggestion1: write an analyzeLine helper method to process each line.
        // Suggestion2: write a helper method to remove the trailing 's' froma word.
        // Suggestion3: write a helper method that given a word, look for it in the 
        //              list of WordCounts and returns that object if found, otherwise 
        //              returns null if that word is not on the list. 

        public void analyzeData(string[] textData) 
        {
            //calculate number of qualifying lines
            foreach (string line in textData)
            {
                if (line.Length > 0)
                {
                    analyzeLine(line);
                }
            }

            int wordCountListLength = wordCountList.Count;

            //find lesser of topWordsCount from constructor or lenght of WordCount List
            if (wordCountListLength >= topWordsCount)
            {
                finalResultsArrayLength = topWordsCount;
            }
            else
            {
                finalResultsArrayLength = wordCountListLength;
            }

            resultData = new string[finalResultsArrayLength];
        }


        /* Implement getResultData:
         * Return an array with data from the result of the analysis.
         * In this case, the array will contain only the n most frequently observed words
         * in the text in descending order: the most frequently observed word first, etc. 
         * Note the array will contain only the words and not the counts. 
         */
        public string[] getResultData() 
        {
            wordCountList.Sort();

            int wordCountListLength = wordCountList.Count;
            int lastIndex = wordCountListLength - 1;
            int firstIndex = wordCountListLength - finalResultsArrayLength;
            int resultDataIndex = 0;

            for (int index = lastIndex; index >= firstIndex; index--)
            {
                resultData[resultDataIndex] = wordCountList[index].getWord(); //for ArrayList, use get() method
                resultDataIndex++;
            }

            return resultData; 
        }

        /* Implement getReportStr:
         * Assembles and returns the report as a String of the top n most commonly 
         * occurring words in this format:
         *          Top N most common words of length > 4.
         *          word1 count1 
         *          word2 count2
         *          etc...
         *          wordN countN
         * -where N is the number passed in to this constructor.
         * See the documentation for examples.
        */
        public string getReportStr() 
        {
            string result = "Top " + topWordsCount +" most common words of length > 4";

            wordCountList.Sort();

            int wordCountListLength = wordCountList.Count;
            int lastIndex = wordCountListLength - 1;
            int firstIndex = wordCountListLength - finalResultsArrayLength;

            for (int index = lastIndex; index >= firstIndex; index--)
            {
                result = result + "\r\n";
                result = result + wordCountList[index].toString(); //for ArrayList, use get() method
            }

            return result; 
        }


        private void analyzeLine(string line)
        {
            //string[] tokens = line.Split("[,.;:?!() ]"); java way

            //C# way
            char[] charSeparators = new char[] { ',', '.', ';', ':', '?', '!', '(', ')', ' ' };
            string[] tokens = line.Split(charSeparators, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                string processedToken = processWord(token);
                if (processedToken.Length >= minWordLength)
                {
                    WordCount wordCount = FindWordCountInWordList(processedToken);

                    if(wordCount != null)
                    {
                        wordCount.incCount();
                    }
                    else
                    {
                        WordCount newWordCount = new WordCount(processedToken);
                        wordCountList.Add(newWordCount);
                    }
                }
            }
        }

        private string processWord(string word)
        {
            string processedWord = word;

            if(word.EndsWith(forbiddenTerminalLetter))
            {
                int wordLength = word.Length;
                processedWord = word.Substring(0, wordLength - 1);
            }

            return processedWord;
        }

        private WordCount FindWordCountInWordList(string targetWord)
        {
            //if we don't find the passed in word, foundWord will be returned as null.
            //if we do find the WordCount object that contains the passed in word, this
            //variable will be updated to refer to the WordCount object
            WordCount foundWord = null;

            foreach(WordCount wordCount in wordCountList)
            {
                if (wordCount.containsWord(targetWord))
                {
                    foundWord = wordCount;
                    break;
                }
            }

            return foundWord;
        }
    }

}