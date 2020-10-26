using System;
using System.Collections.Generic;
using Godot;

abstract class Room
{
    private static int width = 10;
    private static int height = 8;
    private bool isSet = false;

    protected int[,] template;

    List<int[,]> templates;

    public Room()
    {
        
    }


    public static int Width { get => width; set => width = value; }
    public static int Height { get => height; }
    protected bool IsSet { get => isSet; }
    public int[,] Template { get => template;}
}

