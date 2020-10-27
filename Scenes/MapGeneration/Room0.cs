﻿using System;
using Godot;

class Room0 : Room
{  
    public Room0(bool isSet) :base(isSet)
    {
        template = new int[10, 8]{ 
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,1,1,1,1,0,0},
        {0,0,1,1,1,1,1,0},
        {0,0,1,1,1,1,1,0},
        {0,0,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0}};
    }

    public override string ToString()
    {
        return "0";
    }
}

