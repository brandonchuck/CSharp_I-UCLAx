using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Adding elements of OOP to further game complexity
/// </summary>
namespace Assignment_2
{
    class Connections
    {

        // Room Descriptions
        const string ENTRANCE_DESCRIPTION = "You are in the entrance hall. There is a door to the north.";
        const string LIVING_DESCRIPTION = "You are in the living room. There are doors to the north, south, east, and west. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.";
        const string KITCHEN_DESCRIPTION = "You are in the kitchen. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.";
        const string BEDROOM_DESCRIPTION = "You are in the fancy bedroom. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.";
        const string PAINTING_DESCRIPTION = "You are in the painting room. There is a harpsichord, and a large medieval oil painting. The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.";


        // Error message when player requests invalid direction
        const string ERROR_MESSAGE = "Cannot move in that direction.";


        // create a "room" that represents/stores that current room you are in. Can think of this as a variable.
        public Room CurrentRoom { get; set; }



        // Use brace initialization to initialize an object for each room and "set" a value for its Description
        // Only the Game class knows about each of these instances of room... by adding _ before object name, we make it restricted to this class only...
        // Since these are Room class objects, they have access to Room class fields/properties, like Description

        // create entrance hall - instantiate & "set" value for Description
        private Room _entranceHall = new Room()
        {
            Description = ENTRANCE_DESCRIPTION       // assigning a value to Description for the _entranceHall Room object
        };



        // using brace initialization to create objects and setting Description value for each room
        // create living room & "set" value for Description
        private Room _livingRoom = new Room()
        {
            Description = LIVING_DESCRIPTION         // assigning a value to Description for the _livingRoom Room object
        };


        // create kitchen & "set" value for Description
        private Room _kitchen = new Room()
        {
            Description = KITCHEN_DESCRIPTION        // assigning a value to Description for the _kitchen Room object
        };


        // create painting room & "set" value for Description
        private Room _paintingRoom = new Room()
        {
            Description = PAINTING_DESCRIPTION       // assigning a value to Description for the _paintingRoom Room object
        };


        // create fancy bedroom & "set" value for Description
        private Room _fancyBedroom = new Room()
        {
            Description = BEDROOM_DESCRIPTION        // assigning a value to Description for the _fancyBedroom Room object
        };


        // Manipulate state of CurrentRoom
        // Can move north
        public void CanMoveNorth()
        {
            if (CurrentRoom.NorthRoom != null) // if north room exists
            {
                CurrentRoom = CurrentRoom.NorthRoom; // CurrentRoom now either _livingRoom or _fancyBedroom
            }
            else
            {
                PrintError();
            }
        }


        // Can move south
        public void CanMoveSouth()
        {
            if (CurrentRoom.SouthRoom != null) // if south room exists
            {
                CurrentRoom = CurrentRoom.SouthRoom; // CurrentRoom now either _livingRoom or _entranceHall 
            }
            else
            {
                PrintError();
            }
        }


        // Can move east
        public void CanMoveEast() {
            if (CurrentRoom.EastRoom != null) // if east room exists
            {
                CurrentRoom = CurrentRoom.EastRoom; // CurrentRoom now either _livingRoom or _kitchen
            }
            else
            {
                PrintError();
            }
        }


        // Can move west
        public void CanMoveWest()
        {
            if (CurrentRoom.WestRoom != null) // if west room exists
            {
                CurrentRoom = CurrentRoom.WestRoom; // CurrentRoom now either _livingRoom or _paintingRoom 
            }
            else
            {
                PrintError();
            }
        }


        // Print error message
        public void PrintError()
        {
            Console.WriteLine(ERROR_MESSAGE);
        }




        // Overwriting the default constructor
        // Notice that the custom constructor has the same name as the class, this is how you know its a constructor and not just some method within the class
        // Every time a Game() object is instantiated, this logic will run...

        // CONSTRUCTOR for the Game class
        public Connections()
        {

            // initialize current room to _entranceHall per specification
            CurrentRoom = _entranceHall;


            // from here on if we refernece the CurrentRoom in another class, we have access to the different rooms we created objects for and their properties (Description)
            // connections from entrance hall
            _entranceHall.NorthRoom = _livingRoom;


            // connections from living room
            _livingRoom.NorthRoom = _fancyBedroom;
            _livingRoom.SouthRoom = _entranceHall;
            _livingRoom.EastRoom = _kitchen;
            _livingRoom.WestRoom = _paintingRoom;


            // connections from kitchen
            _kitchen.WestRoom = _livingRoom;


            // connections from fancy bedroom
            _fancyBedroom.SouthRoom = _livingRoom;


            // connections from painting room
            _paintingRoom.EastRoom = _livingRoom;

        }
    }
}
