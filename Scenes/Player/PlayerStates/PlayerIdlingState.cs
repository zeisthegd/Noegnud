using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class PlayerIdlingState : PlayerState
{
    public PlayerIdlingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void HandleKeypressEvent()
    {
        PressLeft();
        PressRight();
        PressUp();
        PressDown();
        PressAttack();

        PlayAnimation();
        if (PlayerMovementHandler.PlayerVelocity != Vector2.Zero)
            ChangeToRunning();

       
    }
    public override void PressLeft()
    {

    }
    public override void PressRight()
    {

    }
    public override void PressUp()
    {

    }
    public override void PressDown()
    {

    }

    public override void PressAttack()
    {
        base.PressAttack();
    }

    public override void PlayAnimation()
    {
        base.PlayAnimation();
        playerStateMachine.Player.AnimationPlayer.Play("Idle" + animationDirection);
    }
}
