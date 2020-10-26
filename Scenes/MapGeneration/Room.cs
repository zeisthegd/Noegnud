using System;
using Godot;

class Room
{
    private static int width = 10;
    private static int height = 8;
    private bool isSet = false;

    public static int Width { get => width; set => width = value; }
    public static int Height { get => height; }
    protected bool IsSet { get => isSet; }
}

