using System;
using Godot;

class ChanceCounter
{
    public static bool Hit(float percent)
    {
        return ((GD.Randi() % 100 ) <= percent);
    }
}
