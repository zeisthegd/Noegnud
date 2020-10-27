using System;
using Godot;

class Room1 : Room
{
    public Room1(bool isSet) : base(isSet)
    {
        template = new int[10,8]{ 
        {1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1}};
    }

    public override string ToString()
    {
        return "1";
    }
}

