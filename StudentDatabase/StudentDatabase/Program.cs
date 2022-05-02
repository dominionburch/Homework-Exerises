using System;
using System.Collections.Generic;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating three arrays with filled information of several students
            string[] name = new string[] {"Tara Wilds", "Jack Malice", "Mike Kage", "Julian Yates" };
            string[] hometown = new string[] {"Detroit", "Ann Arbor", "Pontiac", "Trenton"};
            string[] favFood = new string[] {"Italian", "Thai", "Mexican", "Chinese"};
            int userNumber = 0, userAgain = 0, select = 0;
            bool runDatabase = true, validate = true;
            string userCategory = "";


            //Using a while loop to continue the inquiry until the user chooses to stop
            while (runDatabase)
            {
                //Asking the user if they wish to see a list of students
                Console.WriteLine("Welcome to Student Database. \nDo you wish to see a list of student? \n 1. Yes\n2. No \n");
                select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    for (int i = 0; i < name.Length; i++)
                        Console.WriteLine($"{i + 1}. {name[i]}");
                }
                else if (select == 2)
                    break;
                else if(select > 2 || select < 1)
                {
                    Console.WriteLine("Invalid Entry. No students will be listed");
                }

                //Validating userNumber with a while loop
                while (userNumber == 0 || userNumber > 4)
                {
                    //Asking the user for a number that correspond to a particular student
                    Console.WriteLine("\nEnter a number from 1 to 4 to see a student. \nNext, enter either 1 or 2 to select category." +
                        "\n\nNOTE: This question will repeat if you enter any number outside the range\n\n");
                    Console.Write("Enter a number: ");
                    userNumber = int.Parse(Console.ReadLine());

                }

                //Validating userCategory with a while loop
                while(validate)
                {
                    Console.Write("\nType a category: \n1. Hometown \n2. Food \n");
                    userCategory = Console.ReadLine();

                    if (userCategory.ToLower() == "hometown" || userCategory.ToLower() == "food")
                    {
                        validate = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. Please try again.");
                        validate = true;
                    }

                }

                //Subtracking 1 from userNumber and userCategory to match array placement values
                userNumber -= 1;
                //userCategory -= 1;

                //Displaying the selected information the user chose to see
                Console.WriteLine($"\n\nStudent: {name[userNumber]}.");

                if (userCategory.ToLower() == "hometown")
                    Console.WriteLine($"Hometown: {hometown[userNumber]}");
                else
                    Console.WriteLine($"Favorite Food: {favFood[userNumber]}");

                //Validating userAgain with a while loop
                while(userAgain > 2 || userAgain <1)
                {
                    //Asking the user is they would like to go again
                    Console.Write("\n\nNOTE: This question will repeat if you enter any other number than 1 or 2. \nDo you wish to go again to learn about another student? (1. yes or 2 no)");
                    userAgain = int.Parse(Console.ReadLine());

                }

                //testing the response of the user. If the user's response is 1, then all variables are reset to 0 and the loop is ran again.
                //If no, the loop is terminated. 
                if (userAgain == 1)
                {
                    runDatabase = true;
                    userNumber = 0;
                    userCategory = "";
                    userAgain = 0;
                }
                else
                    runDatabase = false;

            }

        }
    }
}
