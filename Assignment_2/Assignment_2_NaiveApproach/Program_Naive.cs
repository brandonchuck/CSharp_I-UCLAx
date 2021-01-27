// Brandon Chuck
using System;

namespace Assignment_2
{
    class AdeventureGame
    {
        // Declare Constant Variables
        const string NORTH = "north";   // Player inputs north
        const string SOUTH = "south";   // Player inputs south
        const string EAST = "east";     // Player inputs east
        const string WEST = "west";     // Player inputs west

        // Locations
        const string ENTRANCE_HALL = "entrance";    //  Current location is the Entrance Hall
        const string LIVING_ROOM = "living room";   //  Current location is the Living Room
        const string KITCHEN = "kitchen";           //  Current location is the Kitchen
        const string BEDROOM = "bedroom";           //  Current location is the Fancy Bedroom
        const string PAINTING_ROOM = "painting";         //  Current location is the Painting Room

        // Room Descriptions
        const string ENTRANCE_DESCRIPTION = "You are in the entrance hall. There is a door to the north.";
        const string LIVING_DESCRIPTION = "You are in the living room. There are doors to the north, south, east, and west. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.";
        const string KITCHEN_DESCRIPTION = "You are in the kitchen. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.";
        const string BEDROOM_DESCRIPTION = "You are in the fancy bedroom. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.";
        const string PAINTING_DESCRIPTION = "You are in the painting room. There is a harpsichord, and a large medieval oil painting. The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.";
        
        // Error message when player requests unavailable direction
        const string ERROR_MESSAGE = "Cannot move in that direction.";


        // Main Function
        static void Main(string[] args)
        {
            // Call function
            AdventureGame();

        }


        // Adventure Game function
        static void AdventureGame() {

            // Always start player in the entrance hall.
            string current_room = ENTRANCE_HALL;
            Console.Write($"{ENTRANCE_DESCRIPTION}\n>", ENTRANCE_DESCRIPTION);

            // Prompt player for direction input
            string direction = Console.ReadLine();

            // Enter do-while loop
            do
            {

                // Player in Entrance Hall
                if (current_room == ENTRANCE_HALL)
                {

                    // Go north
                    if (direction == NORTH)
                    {

                        current_room = LIVING_ROOM; // Move player to Living Room
                        Console.Write($"{LIVING_DESCRIPTION}\n>", LIVING_DESCRIPTION); // Always start player in entrance hall.

                    }
                    else if (direction == "quit")
                    {
                        Console.Write("Goodbye.");
                        return; // exit console program

                    } 

                    // Display error if player doesn't input north
                    else 
                    {

                        Console.WriteLine(ERROR_MESSAGE);   // Notify player you can only move north while in entrance hall.
                        Console.Write($"{ENTRANCE_DESCRIPTION}\n>", ENTRANCE_DESCRIPTION); // Player remains in Entrance Hall

                    }
                }

                // Player in Living Room
                else if (current_room == LIVING_ROOM)
                {

                    // Go North
                    if (direction == NORTH)
                    {

                        // player now in Fancy Bedroom
                        current_room = BEDROOM; // Move player to Fancy Bedroom
                        Console.Write($"{BEDROOM_DESCRIPTION}\n>", BEDROOM_DESCRIPTION);

                    }

                    // Go South
                    else if (direction == SOUTH)
                    {

                        // player now in Entrance Hall
                        current_room = ENTRANCE_HALL; // Move player to Entrance Hall
                        Console.Write($"{ENTRANCE_DESCRIPTION}\n>", ENTRANCE_DESCRIPTION);

                    }

                    // Go East
                    else if (direction == EAST)
                    {

                        // player now in Kitchen
                        current_room = KITCHEN; // Move player to Kitchen
                        Console.Write($"{KITCHEN_DESCRIPTION}\n>", KITCHEN_DESCRIPTION);

                    }

                    // Go West
                    else if (direction == WEST)
                    {

                        // player now in Painting Room
                        current_room = PAINTING_ROOM;    // Move player to Painting Room
                        Console.Write($"{PAINTING_DESCRIPTION}\n>", PAINTING_DESCRIPTION);

                    }

                    else if (direction == "quit")
                    {
                        Console.Write("Goodbye.");
                        return; // exit console program

                    }
                }

                // Player in Kitchen
                else if (current_room == KITCHEN)
                {

                    // Go West
                    if (direction == WEST)
                    {

                        // player now in Living Room
                        current_room = LIVING_ROOM; // Move player to Living Room
                        Console.Write($"{LIVING_DESCRIPTION}\n>", LIVING_DESCRIPTION);
                    }

                    else if (direction == "quit")
                    {
                        Console.Write("Goodbye.");
                        return; // exit console program

                    }

                    // Display error if player doesn't inputs west
                    else
                    {

                        // Notify player cannot go in this direction
                        Console.WriteLine(ERROR_MESSAGE);
                        Console.Write($"{KITCHEN_DESCRIPTION}\n>", KITCHEN_DESCRIPTION); // Player remains in Kitchen

                    }
                }

                // Player in Painting Room
                else if (current_room == PAINTING_ROOM)
                {

                    // Go East
                    if (direction == EAST)
                    {

                        // player now in Living Rom
                        current_room = LIVING_ROOM; // Move player to Living Room
                        Console.Write($"{LIVING_DESCRIPTION}\n>", LIVING_DESCRIPTION);
                    }

                    else if (direction == "quit")
                    {
                        Console.Write("Goodbye.");
                        return; // exit console program

                    }

                    // Display error if player doesn't input east
                    else
                    {

                        // Notify player cannot go in this direction
                        Console.WriteLine(ERROR_MESSAGE);
                        Console.Write($"{PAINTING_DESCRIPTION}\n>", PAINTING_DESCRIPTION); // Player remains in Painting Room


                    }
                }

                // Player in Fancy Bedroom
                else if (current_room == BEDROOM)
                {

                    // Go South
                    if (direction == SOUTH)
                    {

                        // player now in Living Rom
                        current_room = LIVING_ROOM; // Move player to Living Room
                        Console.Write($"{LIVING_DESCRIPTION}\n>", LIVING_DESCRIPTION);
                    }

                    else if (direction == "quit")
                    {
                        Console.Write("Goodbye.");
                        return; // exit console program

                    }

                    // Display error if player doesn't input south
                    else
                    {

                        // Notify player cannot go in this direction
                        Console.WriteLine(ERROR_MESSAGE);
                        Console.Write($"{BEDROOM_DESCRIPTION}\n>", BEDROOM_DESCRIPTION); // Player still in Facny Bedroom

                    }
                }

                // Prompt player for direction again
                direction = Console.ReadLine();

            } while (direction != "quit");  // if player enters quit, the loop will stop and program will exit.
        }
    }
}