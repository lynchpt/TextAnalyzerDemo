using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer
{
    /*
     * LineCountAnalyzer: this class maintains a count of the number
     * of lines of text. Only lines of length>0 are counted.
     */

    public class LineCountAnalyzer : TextAnalyzer
    {

        // TODO1: write the rest of this class. Declare any instance variables you need
        // and implement the TextAnalyzer methods.
        // Hint: You will need a variable to count with and a String Array

        private const int resultDataArrayLength = 1;
        private const int resultDataArrayLineCountIndex = 0;

        private int lineCount = 0;
        private string[] resultData = new string[resultDataArrayLength];

        /* Implement analyzeData:
         * Count the lines of length > 0. 
         */
       public void analyzeData(String[] textData)
        {
            //calculate number of qualifying lines
            foreach(string line in textData)
            {
                if (line.Length > 0)
                {
                    lineCount++;
                }
            }

            // put the line count into the results array
            resultData[resultDataArrayLineCountIndex] = lineCount.ToString();
        }

        /* 
         * Implement getResultData:
         * Returns an array with data from the result of the analysis.
         * In this case, there will be one value in this array- the line count. 
         * Note the array is of type String, so an int must be 
         * converted to a String before it can be placed on the array.
         */
        public String[] getResultData()
        {
            return resultData;
        }

        /* Implement getReportStr:
         * For e.g. if the count was 250, then return the line count as a String in this format:
         * "Number of non-blank lines: 250" 
         */
        public String getReportStr()
        {
            string report = "Number of non - blank lines: " + lineCount.ToString();
            return report;
        }
    }
}
