using System;
using System.Collections.Generic;

namespace ExponentsApril19th
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables for the programs use.
            int userInput; //...to collect the user's integer input
            bool cont = true;//...to continue running the while loop until false
            string keepGoing; //...to store user's input whether to keep going or not


            //Introducing user to the program
            Console.WriteLine("Welcome to The Exponent Program");
            Console.WriteLine("This program will take a number from you and increment it, square it then cube it.");
            Console.WriteLine("WARNING: Maximum cube number is 1290");
            Console.WriteLine();

            while(cont)
            {
                Console.Write("Please enter an integer: ");
                userInput = int.Parse(Console.ReadLine());

                //Validating users input
                while (userInput <= 0 || userInput >= 1291)
                {
                    Console.WriteLine("The number you entered is invalid.");
                    Console.WriteLine("The number must NOT be negative or 0 or more than 1290.");
                    Console.Write("Please enter a valid number: ");
                    userInput = int.Parse(Console.ReadLine());
                }

                //Title for the console output
                Console.WriteLine($"Number \t\t Squared \t\t Cubed");
                Console.WriteLine($"----- \t\t ----- \t\t -----");

                //Looping to increment the index variable "i" for the square and cube until it reaches the user's input integer
                for(int i = 1; i <= userInput; i++)
                {
                    Console.WriteLine($"{i} \t\t " + GetSquare(i) + $" \t\t " + GetCube(i));
                }

                //Asking the user if they wish to continue
                Console.WriteLine();
                Console.Write("Do you wish to continue? (y/n): ");
                keepGoing = Console.ReadLine();

                //Checking users response whether they want to continue or not
                if (keepGoing == "y" || keepGoing == "Y")
                {
                    cont = true;
                }
                else if(keepGoing == "n" || keepGoing == "N")
                {
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Invalid Entry. The Program is terminating.");
                    break;
                }
            }


        }

        static int GetSquare(int num)
        {
            //Squaring the number passed to the method
            num = num * num;

            return num;
        }

        static int GetCube(int num)
        {
            //Cubing the number passed to this method
            num = num * num * num;

            return num;
        }
    }
}
