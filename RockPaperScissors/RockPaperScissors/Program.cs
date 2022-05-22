using System;
using System.Collections.Generic;

namespace RockPaperScissors
{

    //-----------------------------------------Program Class-----------------------------------------//
    //---------------------------------------------with----------------------------------------------//
    //-------------------------------------------Main Method-----------------------------------------//
    //------------------------------------------TESTING AREA-----------------------------------------//

    class Program
    {
        static void Main(string[] args)
        {
            //Creating variables to (1) get user's name and  (2) select and opponent
            string humanPlayerName = "";
            string playAgain = "";
            Roshambo humanMove = 0;
            Roshambo opponentsMove = 0;
            int selectOpponent = -1;
            bool stillAsking = true;
            bool continueGame = true; // used to continue or end entire program

            while (continueGame)
            {


                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("------------------Welcome to Rock Paper and Scissors--------------------------");
                Console.WriteLine("------------------------------------------------------------------------------\n\n");
                Console.Write("First, enter your name --> ");
                humanPlayerName = Console.ReadLine();

                //Creating HumanPlayer object after user give their name. Then taking in roshambo value from HumanPlayer object
                HumanPlayer humanplayer = new HumanPlayer(humanPlayerName);
                humanMove = humanplayer.GenerateRoshambo();
                Player opponent;

                //Asking player to select their opponent and validating their input.
                while (stillAsking && selectOpponent == -1)
                {
                    Console.WriteLine("Third, pick a player: \n 0 = RockPlayer\n 1 = RandomPlayer\n");
                    selectOpponent = int.Parse(Console.ReadLine());

                    if (selectOpponent == 0)
                        stillAsking = false;
                    else if (selectOpponent == 1)
                        stillAsking = false;
                    else
                    {
                        Console.Write("Invalid Input.\n");
                        selectOpponent = -1;
                    }
                }

                //  Running a decision statement to create opponent objects AND
                //  Executing decision statments to render the game.
                if (selectOpponent == 0)
                {
                    opponent = new RockPlayer();
                    opponentsMove = opponent.GenerateRoshambo();

                    if (humanMove == Roshambo.Rock && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose rock. RockPlayer chose rock. \nIts a TIE!");
                    else if (humanMove == Roshambo.Paper && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose paper. RockPlayer chose rock. \nYou WIN!");
                    else if (humanMove == Roshambo.Scissors && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose scissors. RockPlayer chose rock. \nYou LOSE!");
                }
                else if (selectOpponent == 1)
                {
                    opponent = new RandomPlayer();
                    opponentsMove = opponent.GenerateRoshambo();

                    if (humanMove == Roshambo.Rock && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose rock. RandomPlayer chose rock. \nIts a TIE!");
                    else if (humanMove == Roshambo.Paper && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose paper. RandomPlayer chose rock. \nYou WIN!");
                    else if (humanMove == Roshambo.Scissors && opponentsMove == Roshambo.Rock)
                        Console.WriteLine($"{humanplayer.playerName} chose scissors. RandomPlayer chose rock. \nYou LOSE!");
                    else if (humanMove == Roshambo.Rock && opponentsMove == Roshambo.Paper)
                        Console.WriteLine($"{humanplayer.playerName} chose rock. RandomPlayer chose paper. \nYou LOSE!");
                    else if (humanMove == Roshambo.Paper && opponentsMove == Roshambo.Paper)
                        Console.WriteLine($"{humanplayer.playerName} chose paper. RandomPlayer chose paper. \nIts a TIE!");
                    else if (humanMove == Roshambo.Scissors && opponentsMove == Roshambo.Paper)
                        Console.WriteLine($"{humanplayer.playerName} chose scissors. RandomPlayer chose paper. \nYou WIN!");
                    else if (humanMove == Roshambo.Rock && opponentsMove == Roshambo.Scissors)
                        Console.WriteLine($"{humanplayer.playerName} chose rock. RandomPlayer chose scissors. \nYou WIN");
                    else if (humanMove == Roshambo.Paper && opponentsMove == Roshambo.Scissors)
                        Console.WriteLine($"{humanplayer.playerName} chose paper. RandomPlayer chose scissors. \nYou LOSE!");
                    else if (humanMove == Roshambo.Scissors && opponentsMove == Roshambo.Scissors)
                        Console.WriteLine($"{humanplayer.playerName} chose scissors. RandomPlayer chose scissors. \nIts a TIE!");
                }

                //Ending or continuing game
                Console.Write("\nThank you for playing.\nDo you want to play again? (y/n) --> ");
                playAgain = Console.ReadLine();

                if (playAgain.ToLower() == "y")
                {
                    continueGame = true;
                    selectOpponent = -1;
                    stillAsking = true;
                }
                else if (playAgain.ToLower() == "n")
                    continueGame = false;
                else
                {
                    Console.WriteLine("Invalid Entry. The game is ending. \n\n BYE BYE!");
                    continueGame = false;
                }

            }
        }
    }




    //-----------------------------------------Enumeration-----------------------------------------//
    //---------------------------------------------&&----------------------------------------------//
    //-----------------------------------------Parent Class----------------------------------------//

    public enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }

    public abstract class Player
    {
        Roshambo choice;
        string name;

        public abstract Roshambo GenerateRoshambo();
    }




    //-----------------------------------------SubClasses-----------------------------------------//
    //-----------------------------------------SubClasses-----------------------------------------//
    //-----------------------------------------SubClasses-----------------------------------------//

    public class RockPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }

    public class RandomPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            //Creates random object to generate a random value between 0-2 to store in another variable, randValue. 
            var rand = new Random();
            int randValue = rand.Next(2);

            //Running decision statements to send the random rock paper scissor selection
            if (randValue == 0)
                return Roshambo.Rock;
            else if (randValue == 1)
                return Roshambo.Paper;
            else if (randValue == 2)
                return Roshambo.Scissors;

            return 0;
        }
    }



    public class HumanPlayer : Player
    {
        public string playerName           { get; set; }

        public HumanPlayer(string newName)
        {
            playerName = newName;
        }


        public override Roshambo GenerateRoshambo()
        {
            //Creating variables to validate users input when selecting between Rock, Paper or Scissors
            bool continueAsking = true;
            int selectionNumber = 0;


            // Running logic to validate user input. Loop asks the user to enter a number. It takes in an integer.
            // If the integer is between. 0 - 2 then the method returns the appropriate Roshambo value. 
            // Otherwise, if the user enters any other value, the question restarts. 
            while (continueAsking)
            {
                Console.WriteLine("\nSecond, pick your hand. \n 0 = Rock\n 1 = Paper\n 2 = Scissors\n-------INVALID INPUT WILL RESTART THE SELECTION-------\n");
                Console.Write("Choose --> ");
                selectionNumber = int.Parse(Console.ReadLine());

                //Running decision statments to check users input
                if (selectionNumber == 0)
                {
                    return Roshambo.Rock;
                    continueAsking = false;
                }
                else if (selectionNumber == 1)
                {
                    return Roshambo.Paper;
                    continueAsking = false;
                }
                else if (selectionNumber == 2)
                {
                    return Roshambo.Scissors;
                    continueAsking = false;
                }
                else
                    continueAsking = true;
            }

            return 0;
        }
    }

}

