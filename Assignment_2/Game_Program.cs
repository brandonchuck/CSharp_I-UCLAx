using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// Adding elements of OOP to further game complexity
/// </summary>
namespace Assignment_2
{
    class Game_Program
    {

        // Define constants
        const string NORTH = "north";  // for NORTH switch case
        const string SOUTH = "south";  // for SOUTH switch case
        const string EAST = "east";    // for EAST switch case
        const string WEST = "west";    // for WEST switch case


        static void Main(string[] args)
        {

            // instantiate new Connections class object called "game"; constructor made in Connections class will run and setup connections logic
            Connections game = new Connections();  // all logic setup by calling Connections() constructor in Connections class

            // enter loop
            while (true)
            {

                // always print the CurrentRoom's Description property!
                Console.WriteLine(game.CurrentRoom.Description);        // starts off as _entranceHall; will print _entranceHall's Description
                Console.Write("> ");

                // change user input to always be lowercase
                string input = Console.ReadLine().ToLower();


                // exit program if user enters "quit" 
                if (input == "quit")
                {
                    break;
                }


                // user direction logic
                switch (input)
                {
                    // try go north
                    case NORTH:

                        game.CanMoveNorth();
                        break;

                     // try go south
                    case SOUTH:    // checks if input == SOUTH

                        game.CanMoveSouth();
                        break;

                    // try go east
                    case EAST:     // checks if input == EAST

                        game.CanMoveEast();
                        break;

                    // try go west
                    case WEST:     // checks if input == WEST

                        game.CanMoveWest();
                        break;

                    // if anything else, throw error
                    default:
                        game.PrintError();
                        break;
                }
            }

            Console.WriteLine("Goodbye...");

        }
    }
}
