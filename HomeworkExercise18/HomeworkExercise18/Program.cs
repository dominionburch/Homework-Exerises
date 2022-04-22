using System;
using System.Collections.Generic;

namespace HomeworkExercise18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Presenting the program and asking the user to enter a number
            Console.WriteLine("This program will calculate the sum of all the numbers from 1 to the number you enter.");
            AccumulateNum();
        }

        public static void AccumulateNum()
        {
            //Local variable for while loop to continue running until changed
            bool cont = true;
            int enterNumber;
            char answer;

            //Running a loop to calculate the sum of all the number until the users input.
            while (cont)
            {
                int total = 0;

                //Asking for the user's input
                Console.Write("Please enter a number: ");
                enterNumber = int.Parse(Console.ReadLine());

                //Running a loop to add the index variable to the total variable every time the loop runs.
                for (int startingNumber = 1; startingNumber <= enterNumber; startingNumber++)
                {
                    total += startingNumber;
                }

                //Showing the user the results of the calculation
                Console.WriteLine();
                Console.WriteLine($"The sum of all the numbers from 1 to {enterNumber}, is {total}");
                Console.Write("Would you like to go again? (y/n) ");
                answer = Char.ToLower(Convert.ToChar(Console.ReadLine()));

                //Checking whether user wants to run the program again.
                if (answer == 'y')
                {
                    cont = true;
                    total = 0;
                }
                else
                {
                    Console.WriteLine("Thank You! Goodbye!");
                    break;
                }
            }
        }
    }
}
