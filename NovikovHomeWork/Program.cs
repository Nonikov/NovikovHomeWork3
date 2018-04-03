using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace NovikovHomeWork3._1
{
    static class MaxValueIndex
    {
        //Receiving the index of the element with maxValue
        public static int IndexOfMaxValue(int[] array)
        {
            int maxWordsIndex = 0;
            int maxValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxWordsIndex = i;
                }
            }
            return maxWordsIndex;
        }
    }

    class WithString
    {
        public string StringMethod(string stroka)
        {
            // Split the string into a sentences
            var stArray = stroka.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            // Array for counting words in sentences
            int[] countWords = new int[stArray.Length];

            // Loop for finging the number of words in sentences
            for (int i = 0; i < stArray.Length; i++)
            {
                //Trimming spaces around the edges of one sentence
                stArray[i] = stArray[i].Trim();
                //Word counter
                int amount = 1;

                //Getting char array from a sentece
                var arrayBuf = stArray[i].ToCharArray();

                for (int j = 0; j < arrayBuf.Length; j++)
                {
                    if (arrayBuf[j] == ' ' && arrayBuf[j - 1] != ' ')
                    {
                        amount++;
                    }
                }
                countWords[i] = amount;
            }
            return stArray[MaxValueIndex.IndexOfMaxValue(countWords)];
        }
    }

    class RegexExpressions
    {
        public static string RegexMethod(string stroka)
        {
            int counter = 0;
            Regex regex = new Regex(@"\w[\s\,\w]*[.!?]");
            MatchCollection collection = regex.Matches(stroka);
            int[] countWords = new int[collection.Count];

            foreach (Match sentence in collection)
            {
               
                //Word counter
                int amount = 1;

                //Getting char array from a sentece
                var arrayBuf = sentence.Value.ToCharArray();

                for (int j = 0; j < arrayBuf.Length; j++)
                {
                    if (arrayBuf[j] == ' ' && arrayBuf[j - 1] != ' ')
                    {
                        amount++;
                    }
                }
                countWords[counter++] = amount;
            }

            return collection[MaxValueIndex.IndexOfMaxValue(countWords)].Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string stroka = "Привет Мир, как твои дела? Может мы пойдем с тобой, в день позавечера!? Нет спасибо, не хочу!";

            Console.WriteLine(RegexExpressions.RegexMethod(stroka));
            //Console.WriteLine(new WithString().StringMethod(stroka));

            Console.ReadKey();
        }
    }
}
