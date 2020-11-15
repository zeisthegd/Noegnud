using System;
using Godot;

class Room3 : Room
{
    public Room3(bool isSet) : base(isSet)
    {
        
    }

    protected override void AddTemplates()
    {
        templates.Clear();
        templates.Add(template1);
        templates.Add(template2);
    }

    private int[,] template1 = new int[8, 10]{
        {0,0,0,0,0,0,0,0,0,0},
        {1,1,1,2,2,2,2,1,1,1},
        {0,0,0,0,0,0,0,0,0,0},
        {1,1,2,0,0,0,0,2,1,1},
        {1,1,2,0,0,0,0,2,1,1},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,1,1,1}
    };

    private int[,] template2 = new int[8, 10]{
        {0,0,0,0,0,0,0,0,0,0},
        {0,2,1,1,2,0,0,0,1,0},
        {0,1,1,1,1,0,0,0,1,0},
        {2,1,1,1,1,0,0,2,1,0},
        {0,0,0,0,0,0,0,2,1,0},
        {0,1,1,1,1,1,1,1,1,1},
        {0,2,1,1,1,1,1,1,1,2},
        {1,1,1,1,1,1,1,1,1,1}
    };


    public override string ToString()
    {
        return "3";
    }

    
}

