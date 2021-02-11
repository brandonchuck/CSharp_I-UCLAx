using System;
using System.Collections.Generic;

/**
 * This file contains class definitions for common game objects for the text-style
 * adventure we're writing.
 */


// -------------------- Scoreboard Class --------------------
/// <summary>
/// A scoreboard object that can be used to tabulate a final score.
/// </summary>
public class Scoreboard
{
    public uint Score { get; set; }  // score property that can be changed
}




// -------------------- Item Class --------------------
/// <summary>
/// An item that can be picked up and added to inventory.
/// </summary>
/// // each item has a Name, Description, and  Point Value
public class Item
{
    /// <summary>
    /// The short name used when the item is displayed in lists, etc.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The long description printed from the `describe` command.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gold value used when score is calculated
    /// </summary>
    public uint PointValue { get; set; }


    /// <summary>
    /// Pretty-print the item for display in inventory and rooms.
    /// </summary>
    /// <returns></returns>
  
    public override string ToString()
    {
        return $"{Name}: ({PointValue} gold) {Description}";
    }
}





// -------------------- Room class --------------------
public class Room
{
    // If true, game should end when this room is entered.
    public bool FinalRoom { get; set; }


    public string RoomDescription { get; set; } // every room object can have a description


    // initialize to empty list property for Room object
    public List<Item> Items { get; set; } // each room object can have a list of items (item objects)!


    // initialize to an empty dict property for Room object
    public Dictionary<string, Room> Transitions { get; set; } // dict used to store transitions for each room



    // prints current room, its description, AND items available to pickup
    public void PrintRoom()
    {
        Console.WriteLine(this.RoomDescription);
        if (Items.Count > 0)
        {

            Console.WriteLine("Available Items:");

            foreach (Item item in Items)
            {
                Console.WriteLine($"{item.Name}: ({item.PointValue} gold) {item.Description}"); //invokes Item.ToString()
            }
        }
    }
}



// -------------------- Game class (base class) --------------------
public class Game
{
    protected Scoreboard scoreboard = new Scoreboard(); // initialize scoreboard object
    public Room currentRoom;  // room objects have a currentRoom field
    protected string introduction = ""; // introduction initialized to empty string


    // ----- MY INVENTORY ----- start off w/ no items
    private List<Item> myInventory = new List<Item>();


    // Game class constructor
    public Game() { }


    // Start Game function
    public void StartGame()
    {
        Console.WriteLine(introduction);
        InputLoop();
        PrintScore();
    }




    // -------------------- Take user input and move rooms --------------------
    public void InputLoop()
    {

        // start off w/ no points BEFORE loop so it doesn't always reset to 0 points
        scoreboard.Score = 0;


        // ------ ENTER LOOP ------
        while (true)
        {
            // add item to inventory and remove item from room
            List<Item> RemoveItemsFromRoom_List = new List<Item>();
            List<Item> AddItemToInventory_list = new List<Item>();


            // remove item from inventory and add item to room
            List<Item> AddItemToRoom_List = new List<Item>();
            List<Item> RemoveFromInventory_list = new List<Item>();


            // print current room description and items 
            currentRoom.PrintRoom(); // currentRoom starts off as entranceHall

            // take user input
            Console.Write("> ");
            string input = Console.ReadLine();


            // Check for valid action
            bool isValid = false;



            // ------ PICK UP ITEM ------
            if (input.StartsWith("pick up"))
            {

                // loop thru list of items in currentRoom and if item name is in input, then add item to inventory and tally points
                foreach (Item item in currentRoom.Items){
                    if (input.Contains(item.Name)) {

                        // add item to inventory 
                        AddItemToInventory_list.Add(item);

                        // remove item from current room
                        RemoveItemsFromRoom_List.Add(item);

                        // increase Score
                        scoreboard.Score += item.PointValue;

                        // pick up is valid action
                        isValid = true;


                    }
                }

            }
             

            
            // ------- DROP ITEM -------
            if (input.StartsWith("drop"))
            {
                if (myInventory.Count != 0)
                {
                    foreach (Item item in myInventory)
                    {
                        if (input.Contains(item.Name))
                        {

                            // remove item from current inventory 
                            RemoveFromInventory_list.Add(item);

                            // add item to current room
                            AddItemToRoom_List.Add(item);

                            // increase Score
                            scoreboard.Score -= item.PointValue;

                            // drop item is valid action
                            isValid = true;

                        }
                    }
                }
                else
                {
                    // no items in inventory
                    NoItems();
                    isValid = true;
                }

            }



            // ------- SHOW INVENTORY--------
            if (input.Equals("show inventory"))
            {
                if (myInventory.Count != 0)
                {
                    // print items in myInventory
                    PrintInventory();

                }
                else
                {
                    NoItems();
                }

                // show inventory is valid action
                isValid = true;

            }



            // ------- DESCRIBE AN ITEM -------
            if (input.StartsWith("describe"))
            {

                foreach (Item item in currentRoom.Items)
                {

                    if (input.Contains(item.Name))
                    {
                        Console.WriteLine(item.Description);

                        // item can be described
                        isValid = true;
                    }
                }


                foreach (Item item in myInventory)
                {

                    if (input.Contains(item.Name))
                    {
                        Console.WriteLine(item.Description);

                        // item can be described
                        isValid = true;
                    }

                }
            }



            // -------- TRANSITION ROOMS -------
            // check if input is equal to one of the currentRoom's valid rooms to enter
            if (currentRoom.Transitions.TryGetValue(input, out Room nextRoom)) // special way of declaring nextRoom property; take user input and store it in nextRoom
            {
                currentRoom = nextRoom; // currentRoom changes to user input

                // transition is valid action
                isValid = true;
               
            }



            // ----- IVENTORY & ROOM ACTIONS -----

            // add item to inventory when you pick up
            foreach (Item item in AddItemToInventory_list) {

                // add item to myInventory
                myInventory.Add(item);

                // remove item from current room
                currentRoom.Items.Remove(item);

            }

            // remove item from inventory when you drop 
            foreach (Item item in RemoveFromInventory_list)
            {

                // remove item from myInventory
                myInventory.Remove(item);

                // add item to current room
                currentRoom.Items.Add(item);
            }


            // -------- QUIT GAME --------
            if (input == "quit")
            {
                Console.WriteLine("Goodbye.");
                isValid = true;
                break;
            }


            // ------- CHECK VALID ACTIONS
            if (isValid == false)
            {
                Console.WriteLine("Invalid action.");
            }


            // exit game if current room is the final room
            if (currentRoom.FinalRoom)
            {
                currentRoom.PrintRoom();
                break;
            }

        }

    }


    // -------- FUNCTIONS --------

    // Print current score
    public void PrintScore()
    {
        Console.WriteLine($"Your score was: {scoreboard.Score}");
    }


    // Notify user, no items in inventory.
    public void NoItems()
    {
        Console.WriteLine("No items in inventory.");
    }


    // Print current items in inventory
    public void PrintInventory()
    {
        foreach (Item item in myInventory) {

            Console.WriteLine(item.Name);
        }
    }


}