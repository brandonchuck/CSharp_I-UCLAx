using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Adding elements of OOP to further game complexity
/// </summary>
namespace Assignment_2
{
    public class Room
    {

        // Description property for Room objects  
        public string Description { get; set; } // 


        // Direction properties for each Room object
        public Room NorthRoom { get; set; }
        public Room SouthRoom { get; set; }
        public Room EastRoom { get; set; }
        public Room WestRoom { get; set; }
    }
}
