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

        if (PlayerMovementHandler.PlayerVelocity.x < 0)
            return currentAnimation = "Left";
        else if (PlayerMovementHandler.PlayerVelocity.x > 0)
            return currentAnimation = "Right";
        if (PlayerMovementHandler.PlayerVelocity.y < 0)
            return currentAnimation = "Up";
        else if (PlayerMovementHandler.PlayerVelocity.y > 0)
            return currentAnimation = "Down";

        return currentAnimation;
    }


}
