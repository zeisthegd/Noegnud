using System;
using Godot;

class Room3 : Room
{
    public Room3(bool isSet) : base(isSet)
    {
        template = new int[10, 8]
        {
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1}
        };
    }


    public override string ToString()
    {
        return "3";
    }
}

