using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class PlayerRunningState : PlayerState
{
    public PlayerRunningState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void HandleKeypressEvent()
    {
        PressLeft();
        PressRight();
        PressUp();
        PressDown();

        PlayAnimation();

        if (PlayerMovementHandler.PlayerVelocity == Vector2.Zero)
            ChangeToIdling();

        playerStateMachine.Player.AnimationPlayer.Play("Run" + animationDirection);
    }
    public override void PressLeft()
    {
        base.PressRight();
    }
    public override void PressRight()
    {
        base.PressRight();
    }
    public override void PressUp()
    {
        base.PressUp();
    }
    public override void PressDown()
    {
        base.PressDown();
    }
    public override void PlayAnimation()
    {
        base.PlayAnimation();
    }

}

