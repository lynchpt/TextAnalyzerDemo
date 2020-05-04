namespace TextAnalyzer
{
    /* This class makes a count of the occurrance of all words of length >=4
     * in a text and reports on that count. 
     * Note only words of length > 4 are counted. 
     * 
    */

    public class WordCountAnalyzer : TextAnalyzer
    {
        private const int minWordLength = 5;
        private const int resultDataArrayLength = 1;
        private const int resultDataArrayWordCountIndex = 0;

        private int wordCount = 0;
        private string[] resultData = new string[resultDataArrayLength];

        //TODO2: write the rest of this class. Declare any instance variables you need
        //       and implement the TextAnalyzer methods.
        //       Hint: You will need a variable to count with and a String Array


        /**Implement analyzeData:
        *  This method processes the lines of test, where each line of text is processed
        *  in the following manner:
        *  1) It tokenizes the line of text by calling the String method split with this 
        *     argument:  line.split("[,.;:?!() ]")
        *     Each token is a "word", which is a String in the array returned from the call to split. 
        *  2) Only words of length > 4 are considered in updating the word count.
        **/

        // Suggestion: write an analyzeLine helper method to process each line.
        public void analyzeData(string[] textData)
        {
            //calculate number of qualifying lines
            foreach (string line in textData)
            {
                if (line.Length > 0)
                {
                    //string[] tokens = line.Split("[,.;:?!() ]"); java way

                    //C# way
                    char[] charSeparators = new char[] { ',', '.', ';', ':', '?', '!', '(', ')', ' ' };
                    string[] tokens = line.Split(charSeparators, System.StringSplitOptions.RemoveEmptyEntries); 
                    foreach (string token in tokens)
                    {
                        if(token.Length >= minWordLength)
                        {
                            wordCount++;
                        }
                    }
                }
            }

            // put the line count into the results array
            resultData[resultDataArrayWordCountIndex] = wordCount.ToString();
        }

    /* Implement getResultData:
     * Returns an array with data from the result of the analysis.
     * In this case, there will be one value in this array. 
     * Note the array is of type String, so an int must be 
     * converted to a String before it can be placed on the array.
     */
    public string[] getResultData() 
    { 
        return resultData; 
    }

    /* Implement getReportStr:
     * For e.g. if the word count was 1543, return a count of the number of unique words in a text file
     * as a String in this format:
     * "Number of words of length > 4: 1543" 
     */
    public string getReportStr() 
    {
        string report = "Number of words of length > 4: " + wordCount.ToString();
        return report;
    }
}
}
