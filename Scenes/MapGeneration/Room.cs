using System;
using System.Collections.Generic;
using Godot;

class Room
{
    private static int width = 8;
    private static int height = 10;
    private bool isSet = false;

    protected int[,] template;

    List<int[,]> templates;

    public Room(bool isSet)
    {
        this.isSet = isSet;
    }


    public static int Width { get => width;}
    public static int Height { get => height; }
    public bool IsSet { get => isSet; }
    public int[,] Template { get => template;}
}

