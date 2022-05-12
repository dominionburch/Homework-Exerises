using System;

namespace MyCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring variable for programs use
            double radius = 0;
            bool keepGoing = true;
            bool keepGoing2 = true;
            bool keepGoing3;
            string circum, area, question;
            double circumNum, areaNum;
            int counter = 0;

            //Using a while loop to continually make an object of circle and calculate its circumference and area until the user states otherwise. 
            while(keepGoing2)
            {
                //Asking and validating the user's response for circle object.
                while (keepGoing)
                {
                    Console.Write("Enter a decimal number for your circle's radius:   ");
                    radius = double.Parse(Console.ReadLine());

                    if (radius < 0)
                    {
                        Console.WriteLine($"{radius} is not a valid input. Please try again.");
                        keepGoing = true;

                    }
                    else
                        keepGoing = false;
                }

                Circle myCircle = new Circle(radius);
                circum = myCircle.CalculateFormattedCircumference();
                area = myCircle.CalculateFormattedArea();
                circumNum = myCircle.CalculateCircumference();
                areaNum = myCircle.CalculateArea();

                //Printing out user's number;
                Console.WriteLine($"Raw Circumference is: {circumNum}");
                Console.WriteLine($"Raw Area is: {areaNum}");
                Console.WriteLine($"Formatted Circumference is: {circum}");
                Console.WriteLine($"Formatted Area is: {area}");
                keepGoing3 = true;
                counter += 1; //tallying total number of circles created. 

                while(keepGoing3)
                {
                    Console.WriteLine();
                    Console.Write("\nWould you like to go again? (y/n):  ");
                    question = Console.ReadLine();

                    if (question == "y" || question == "Y")
                    {
                        keepGoing2 = true;
                        radius = 0;
                        keepGoing = true;
                        keepGoing3 = false;
                    }
                    else if (question == "n" || question == "N")
                    {
                        keepGoing2 = false;
                        keepGoing3 = false;
                        Console.WriteLine($"Number of circles built:  {counter}");
                        Console.WriteLine($"\nThank you! Goodbye!");
                    }
                    else
                    {
                        Console.WriteLine($"{question} is an invalid response. ");
                        keepGoing3 = true;
                    }
                }

            }

        }
    }

    public class Circle
    {

        private double radius;



        public Circle(double r)
        {
            radius = r;
        }

        public double CalculateCircumference()
        {
            double circumference;

            circumference = 2 * (Math.PI * radius);

            return circumference;
        }

        public string CalculateFormattedCircumference()
        {
            string x;
            double circum = Convert.ToDouble(FormatNumber(CalculateCircumference()));
            double result;

            result = 2 * (Math.PI * circum);
            result = Math.Round(result, 2);

            x = Convert.ToString(result);

            return x;
        }

        public double CalculateArea()
        {
            double area;

            area = Math.PI * (radius * radius);

            return area;
        }

        public string CalculateFormattedArea()
        {
            string x;
            double area = Convert.ToDouble(FormatNumber(CalculateArea()));
            double result;

            result = Math.PI * (area * area);
            result = Math.Round(result, 2);

            x = Convert.ToString(result);

            return x;
        }

        
        private string FormatNumber(double x)
        {
            string converted;

            converted = Convert.ToString(Math.Round(x, 2));

            return converted;
        }
        

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
    }
}

