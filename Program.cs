using System.Diagnostics.Metrics;
using System.Globalization;

namespace GA_InsertionSort_TylerSimpson
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int size = 10; // Change the size of the array as needed
            int minValue = 1; // Change the minimum value as needed
            int maxValue = 100; // Change the maximum value as needed

            int[] randomArray = GenerateRandomIntArray(size, minValue, maxValue);

            // Display your array in it's unsorted form
            DisplayArray(randomArray);
            Console.WriteLine("\n");
            // Call your bubble sort method
            InsertionSortArray(randomArray);

            // Display your method after its been sorted
            DisplayArray(randomArray);
        }
        static void DisplayArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.WriteLine(element);
            }
        }

        static int[] GenerateRandomIntArray(int size, int minValue, int maxValue)
        {
            if (size <= 0 || minValue > maxValue)
            {
                throw new ArgumentException("Invalid arguments");
            }

            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(minValue, maxValue + 1);
            }
            return arr;
        }

        static void InsertionSortArray(int[] arr)
        {
            //Calculate the length of the array
            int arrayLength = arr.Length;

            //Start a loop  with currentIndex being 1, starting from the second element of the array
            for (int currentIndex = 1; currentIndex < arrayLength; currentIndex++)
            {
                //Store the value of the current element in currentValue
                int currentValue = arr[currentIndex];

                //Initialize previousIndex to one position before currentIndex
                int previousIndex = currentIndex - 1;

                //Start a loop to compare elements and move elements greater than currentValue
                //one position ahead of their current position
                while (previousIndex >= 0 && arr[previousIndex] > currentValue)
                {
                    //we shift the element at previousIndex to the right by assigning arr[previousIndex] to arr[previousIndex + 1].
                    //This step ensures that we make room for currentValue in the correct position.
                    arr[previousIndex + 1] = arr[previousIndex];

                    //Decrement previousIndex by 1 to move to the previous element
                    previousIndex = previousIndex - 1;
                }
                //After the while loop, we place currentValue at its correct sorted position by assigning it to arr[previousIndex + 1].
                //This step completes the insertion of currentValue into the sorted portion of the array.

                //Place currentValue at its correct position in the sorted part of the array
                arr[previousIndex + 1] = currentValue;
            }
        }
    }
}
