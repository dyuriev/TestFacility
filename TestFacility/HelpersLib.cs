using System;
using System.Text;


namespace TestFacility
{
    static class HelpersLib
    {
        /**
         * Implementation of gnome sorting algorithm.
         * 
         * In real apps we must use library sorting method Array.Sort(Array array);
         */
        public static long[] gnomeSort(long[] arrToSort)
        {
            int i = 0;
            int arrCount = arrToSort.Length;

            while (i < arrCount)
            {
                if (i == 0 || arrToSort[i - 1] <= arrToSort[i])
                {
                    i++;
                }
                else
                {
                    long tmp = arrToSort[i];
                    arrToSort[i] = arrToSort[i - 1];
                    arrToSort[--i] = tmp;
                }
            }

            return arrToSort;
        }

        /**
         * Gets data recieved from richTextBox element, splits lines into array, removes useless elements 
         * and returns array of long integer elements.
         */
        public static long[] parseRichTextBoxData(String inputText)
        {
            //List<long> unsortedList = new List<long>();
            long[] unsortedList = new long[] { };
            int j = 0;

            inputText = inputText.Replace("\n", " ");
            String[] lines = inputText.Split(' ');

            foreach (var line in lines)
            {
                long number;
                bool result = Int64.TryParse(line, out number);

                if (result)
                {
                    Array.Resize(ref unsortedList, unsortedList.Length + 1);
                    unsortedList[j] = number;
                    j++;
                    //unsortedList.Add(number);
                }
            }

            //return unsortedList.ToArray();
            return unsortedList;
        }

        /*
         * Checks if a value exists in an array (searches needle in haystack)
         * 
         * Instead of this in real apps we must use library searching method Array.Exists() or Linq Contains()
         */
        public static bool isItemInArray(long needle, long[] haystack)
        {
            foreach (int item in haystack)
            {
                if (item == needle)
                {
                    return true;
                }
            }

            return false;
        }

        /**
         * Gets summ of array items
         */
        public static int getArrayItemsSumm(int[] arr)
        {
            int count = arr.Length;
            int summ = 0;

            for (int i = 0; i < count; i++)
            {
                summ += arr[i];
            }

            return summ;
        }

        /**
         * Find a range of numbers, which are divided without a remainder of 3 or 5
         * 
         * In real apps it is preferable to use List
         */
        public static int[] getNumbers()
        {
            //List<int> numbers = new List<int>();
            int[] numbers = new int[] { };
            int j = 0;

            for (int i = 3; i <= 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Array.Resize(ref numbers, numbers.Length + 1);
                    numbers[j] = i;
                    j++;
                    //numbers.Add(i);
                }
            }

            return numbers;
            //return numbers.ToArray();
        }

        /**
         * Finds single item in array
         * 
         * In real apps we must use Linq (arr.Where(a => arr.Count(x => x == a) == 1);)
         */
        public static long findSingletone(long[] arr)
        {
            int count, i;
            long singleton = 0;

            for (i = 0; i < arr.Length; i++)
            {
                count = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j]) count++;
                }

                if (count == 1)
                {
                    singleton = arr[i];
                    break;
                }
            }

            return singleton;
        }

        /**
         * Checks whether or not the coordinate in the range.
         * The borders of shape are not included in range.
         */
        public static bool checkNumbersInRange(double x, double y)
        {
            bool isInRange = false;

            if (
                (x > 1.0 && x <= 2.0) && (y > 1.0 && y < 2.0) ||
                (x > 2.0 && x <= 3.0) && (y > 1.0 && y < 3.0) ||
                (x > 3.0 && x <= 4.0) && (y > 1.0 && y < 4.0) ||
                (x > 4.0 && x <= 5.0) && (y > 1.0 && y < 5.0) ||
                (x > 5.0 && x <= 6.0) && (y > 1.0 && y < 6.0) ||
                (x > 6.0 && x <= 7.0) && (y > 1.0 && y < 7.0) ||
                (x > 7.0 && x < 8.0) && (y > 1.0 && y < 8.0)
               )
            {
                isInRange = true;
            }

            return isInRange;
        }
    }
}
