using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextAnalyzer
{
    /* 
    * This class reads the contents of a text file and produces the data 
    * as a String array, where each cell in the array contains a line
    * of text from the file.
    */
    public class TextFileReaderWriter
    {
        private List<String> lines;

        public TextFileReaderWriter()
        {
            lines = new List<String>();
        }

        /*
        * Attempts to find and open the file, then puts each line of text
        * into an List.
        */
        public void processFile(String inputFileName)
        {
            string[] readText = File.ReadAllLines(inputFileName);
            lines.AddRange(readText);

            //Scanner scan = new Scanner(new FileReader(inputFileName));
            //while(scan.hasNext())
            //{
            //    lines.add(scan.nextLine());
            //}
            //scan.close();
        }

        /*
        * Returns an array of Strings which are the lines in the text file.
        */
        public String[] getLines()
        {
            string[] strArr = new string[lines.Count];

            strArr = lines.ToArray();
            //return lines.toArray(strArr);
            return strArr;
        }

        /*
        * Writes the report string to the specified file.
        */
        public void writeToFile(String report, String outputFileName)
        {
            File.WriteAllText(outputFileName, report);
            //PrintWriter pw = new PrintWriter(outputFileName);
            //pw.print(report);
            //pw.close();
        }
    }
}
