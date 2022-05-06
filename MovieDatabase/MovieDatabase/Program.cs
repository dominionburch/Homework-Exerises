using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a list of movies
            List<Movies> myMovies = new List<Movies>()
            {
                new Movies ("Dragon Ball Z", "Animated"),
                new Movies ("Night of the Living Dead", "Horror"),
                new Movies ("Star Trek", "SciFi"),
                new Movies ("Star Wars", "SciFi"),
                new Movies ("Why Did I Get Married", "Drama"),
                new Movies ("Sword of the Stranger", "Animated"),
                new Movies ("Grave Encounters", "Horror"),
                new Movies ("Inside Out", "Animated"),
                new Movies ("Mars", "SciFi"),
                new Movies ("The Grudge", "Horror")
            };
            bool run = true;
            bool again = true;
            int categoryEntered = 0;
            string match = "";
            char answer = ' ';

            while (run)
            {
                //Asking the user to selected a category and validating user's input
                Console.Write("Enter a category from the following.\n(USE NUMBERS)\n \n1. Horror\n2. Drama\n3. SciFi\n4. Animated ");
                while (categoryEntered > 4 || categoryEntered < 1)
                {
                    categoryEntered = int.Parse(Console.ReadLine());
                    if (categoryEntered > 4 || categoryEntered < 1)
                        Console.WriteLine($"{categoryEntered} is an invalid entry. Try again.\n");
                }

                //Assigning string literals to match user's input
                if (categoryEntered == 1)
                    match = "Horror";
                else if (categoryEntered == 2)
                    match = "Drama";
                else if (categoryEntered == 3)
                    match = "SciFi";
                else if (categoryEntered == 4)
                    match = "Animated";

                //Scanning the list for the category of movies entered
                List<Movies> scanofMovies = myMovies.Where(s => s.category == match).ToList(); //Collects the elements according to category
                var orderedList = scanofMovies.OrderBy(x => x.title).ToList();  //Orders the elements in the new list


                //Displaying the user's input
                foreach (var x in orderedList)
                    Console.WriteLine($"{x.title}");

                //Asking the user if theyd like to run the program again
                while (again)
                {
                    Console.Write("Answer either y or n.\nWant to go again? (y/n) ---> ");
                    answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'y' || answer == 'Y'|| answer == 'n' || answer == 'N')
                        again = false;
                    else
                    {
                        Console.WriteLine($"{answer} is an invalid entry. Try again.");
                        again = true;
                    }
                }

                if (answer == 'y' || answer == 'Y')
                {
                    run = true;
                    categoryEntered = 0;
                    again = true;
                }
                else
                    run = false;
            }

        }
    }

    class Movies
    {
        public string title;
        public string category;

        public Movies(string newTitle, string newCategory)
        {
            title = newTitle;
            category = newCategory;
        }
    }

    public enum MovieType
    {
        Horror,
        Animated,
        Drama,
        SciFi,
    }
}

