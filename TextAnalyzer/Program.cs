using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFileReaderWriter tfproc = new TextFileReaderWriter();
            List<TextAnalyzer> analyzers = getAnalyzers();
            string inputFileName;
            string outputFileName;
            string[] textData = null;
            string reportStr = null;
            Console.WriteLine("Enter a text file name to analyze:");
            inputFileName = Console.ReadLine();

            try
            {
                tfproc.processFile(inputFileName);
                textData = tfproc.getLines();
            }
            catch (System.IO.IOException ioex)
            {
                Console.WriteLine("Error accessing file: " + inputFileName);
                Console.WriteLine(ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (textData != null)
            {
                foreach (TextAnalyzer curAnalyzer in analyzers)
                {
                    curAnalyzer.analyzeData(textData);
                }

                /************************/
                // To test the getResultData method uncoment:

                string[] resultArr = null;
                Console.WriteLine("\nBEGIN testing getResultData:");
                foreach (TextAnalyzer curAnalyzer in analyzers)
                {
                    resultArr = curAnalyzer.getResultData();

                    foreach (string curRes in resultArr)
                    {
                        Console.WriteLine(curRes);
                    }

                }
                Console.WriteLine("END testing getResultData.\n");

                /******************/


                Console.WriteLine("Analyzed text: " + inputFileName);
                reportStr = getReportStr(analyzers);
                Console.WriteLine(reportStr);
                Console.WriteLine("Enter a file to write report, N to skip. ");
                outputFileName = Console.ReadLine();
                if (! (outputFileName.Equals("N", StringComparison.OrdinalIgnoreCase)))
                {
                    try
                    {
                        tfproc.writeToFile(reportStr, outputFileName);
                    }
                    catch (IOException ioex)
                    {
                        Console.WriteLine("Error accessing file: " + outputFileName);
                        Console.WriteLine(ioex.Message);
                    }
                }
            }

            Console.ReadLine(); //keep program from exiting
        }

        /* Creates a list of the text analyzers to be applied to the text file under analysis.
        Add any new analyzers here by adding an instance of the new analyzer class.
        */
        static List<TextAnalyzer> getAnalyzers()
        {
            List<TextAnalyzer> analyzers = new List<TextAnalyzer>();
            //analyzers.Add(new LineCountAnalyzer());
            //analyzers.Add(new WordCountAnalyzer());
            analyzers.Add(new MostFrequentWordsAnalyzer(5));
            return analyzers;
        }

        static string getReportStr(List<TextAnalyzer> analyzers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TextAnalyzer curAnalyzer in analyzers)
            {
                sb.Append(curAnalyzer.getReportStr());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
