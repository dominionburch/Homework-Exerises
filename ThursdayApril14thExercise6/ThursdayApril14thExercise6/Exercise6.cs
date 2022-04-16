using System;

namespace ThursdayApril14thExercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable for user input
            char choice;

            //Loop to print out Hello World and ask user wether they would like to continue
            do
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine();
                Console.Write("Would you like to continue (y/n)?: ");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'y' || choice == 'Y');

            //Exiting program
            Console.WriteLine("Goodbye!");
        }
    }
}
