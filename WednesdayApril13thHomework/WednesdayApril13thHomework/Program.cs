using System;
using System.Collections.Generic;

namespace WednesdayApril13thHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Decalring variables for number analyzer program
            string enter, name;
            int num, remainder;
            char again = 'y';

            //Asking the user for their input of name and number
            Console.WriteLine("Welcome to number analyzer.");
            Console.WriteLine("This program will analyze the number you enter as either odd or even.");
            Console.WriteLine("It will also analyze the range the number is in.");
            Console.WriteLine();
            Console.Write("First, what is your name?: ");
            name = Console.ReadLine();


            while (again == 'y' || again == 'Y')
            {
                Console.Write("Please enter an integer between 1 and 100: ");
                enter = Console.ReadLine();
                num = int.Parse(enter);

                while (num < 0 || num > 100)
                {
                    Console.WriteLine("Invalid Entry.");
                    Console.WriteLine("Number must be between 1 and 100.");
                    Console.Write("Please enter a valid number: ");
                    enter = Console.ReadLine();
                    num = int.Parse(enter);
                }

                //Calculating whether num is odd or even.
                remainder = num % 2;

                //Evaluating the user's number as either odd or even and analyzing the range.
                if (remainder == 0)
                {
                    if(num > 60)
                        Console.WriteLine(name + ", the number you entered is " + num + " and it is even.");
                    else if (num <= 60 && num >= 26)
                        Console.WriteLine(name + ", the number you entered is even");
                    else if (num <= 25 && num >= 2)
                        Console.WriteLine(name + ", the number you entered is " + num + " and it is even.");
                }
                else if (remainder > 0)
                {
                    if (num > 60)
                    {
                        Console.WriteLine(name + ", the number you entered is " + num + " and it is odd.");
                    }

                    //yConsole.WriteLine(name + ", the number you entered is " + num + " and it is odd.");
                }

                Console.WriteLine(name + ", do you wish to go again?");
                Console.Write("y for YES and n for NO: ");
                again = Convert.ToChar(Console.ReadLine());
                
            }

        }
    }
}
