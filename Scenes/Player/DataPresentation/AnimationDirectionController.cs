using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class AnimationDirectionController
{
    private static string currentAnimation = "Down";
    public static string GetCurrentMovingDirection()
    {

        if (Input.IsActionPressed("move_left"))
            return currentAnimation = "Left";
        else if (Input.IsActionPressed("move_right"))
            return currentAnimation = "Right";
        if (Input.IsActionPressed("move_up"))
            return currentAnimation = "Up";
        else if (Input.IsActionPressed("move_down"))
            return currentAnimation = "Down";

        return currentAnimation;
    }


}
