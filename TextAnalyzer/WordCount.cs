using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer
{
    /*
    * This class encapsulates a word and the number of times it has been
     * observed.
    */

    public class WordCount : IComparable
    {
        string word;
        int count;


        public WordCount(string wd)
        {
            word = wd;
            count = 1;
        }

        /*
         * Returns true if this word is equal to the targetWd.
         */
        public bool containsWord(string targetWd)
        {
            return (word.Equals(targetWd));
        }

        public string getWord() { return word; }

        public void incCount()
        {
            count++;
        }

        public int getCount()
        {
            return count;
        }

        /*
         * Compares this count to the other count.
         * Returns a positive int if this count > other count,
         * returns a negative int if this count < other count,
         * returns 0 if this count = other count.
         */
        public int CompareTo(Object other)
        {
            WordCount otherCount = (WordCount)other;
            return this.count - otherCount.getCount();
        }

        public String toString()
        {
            return word + " " + count;
        }

   }
}
