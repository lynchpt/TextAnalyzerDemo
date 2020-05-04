using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer
{
    /* 
     * This interface defines the methods that all text analyzers must
     * implement.  
     */
    public interface TextAnalyzer
    {

        /* Processes the array of lines from the input file. */
        public void analyzeData(String[] textData);

        /* Return an array with data from the result of the analysis. */
        public String[] getResultData();

        /* Return the String representation of the analysis. */
        public String getReportStr();
    }
}
