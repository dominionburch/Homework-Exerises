using System;

class Program
{
    public static void Main(string[] args)
    {
        //Creating variables to get response from methods
        int sameNum1, sameNum2;
        double diffNum1, diffNum2, result;
        int range;
        bool same = true;
        string type;

        //Asking the user for all the information to demonstrate the methods of the program.
        Console.Write("Enter two numbers to check whether they are the same or not: ");
        sameNum1 = int.Parse(Console.ReadLine());
        sameNum2 = int.Parse(Console.ReadLine());
        same = IsTheSame(sameNum1, sameNum2);

        Console.WriteLine();
        Console.WriteLine("Enter two numbers to check the difference between them: ");
        diffNum1 = double.Parse(Console.ReadLine());
        diffNum2 = double.Parse(Console.ReadLine());
        result = Subtract(diffNum1, diffNum2);

        Console.WriteLine();
        Console.WriteLine("Enter a number to check the type of building it would be: ");
        range = int.Parse(Console.ReadLine());
        type = FindBuildingType(range);

        Console.WriteLine($"It is {same} that both numbers are the same.");
        Console.WriteLine($"The difference between {diffNum1} and {diffNum2} is {result}");
        Console.WriteLine(type);


    }

    static bool IsTheSame(int num1, int num2)
    {
        //Declaring local variables to perform conditional logic
        bool same = true;

        if (num1 == num2)
            same = true;
        else
            same = false;

        return same;
    }

    static double Subtract(double num1, double num2)
    {
        //Declaring local variable to perform subtraction logic
        double diff = 0;

        diff = num2 - num1;

        return diff;
    }

    static string FindBuildingType(int type)
    {
        //Declaring local variable to perform check of numerical range
        //to announce what type of building is represented by the number
        string response = "";

        if (type >= 4 && type <= 10)
            response = "This is an office building!";
        else if (type >= 50)
            response = "This is a SUPER skyscraper!";
        else if (type >= 11 && type <= 49)
            response = "This is a skyscraper!";
        else if (type <= 3)
            response = "This is a house!";

        return response;
    }

}

