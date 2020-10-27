using System;
using Godot;

class Room2 : Room
{
    public Room2(bool isSet) : base(isSet)
    {
        template = new int[10, 8]{
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,1,1,1,0,0,0},
        {0,0,0,1,0,0,0,0},
        {0,0,1,1,1,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0}};
    }
    public override string ToString()
    {
        return "2";
    }
}

