using System;

namespace ThursdayApril14thExerise13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a integer variable for the user to enter a number
            int inputNum, copy;
            char choice = 'y';

            /* Using While loop to ask whether the user wants to continue with
            a for-loop to take user input and decrement the number to zero and print out results to display */
            while(choice == 'y' || choice == 'Y')
            {
                //Using console to ask user for a number
                Console.Write("Enter a number: ");
                inputNum = Convert.ToInt32(Console.ReadLine());
                copy = inputNum;

                for (int nmbr1 = inputNum; nmbr1 != 0; nmbr1--)
                {
                    Console.Write(" " + nmbr1);
                }

                //Spacing
                Console.WriteLine();

                for (int nmbr2 = 1; nmbr2 <= copy; nmbr2++)
                {
                    Console.Write(" " + nmbr2);
                }

                Console.WriteLine();
                Console.Write("Would you like to continue (y/n)? ");
                choice = Convert.ToChar(Console.ReadLine());
            }

        }
    }
}
