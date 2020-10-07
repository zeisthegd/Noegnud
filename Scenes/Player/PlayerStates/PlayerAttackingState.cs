using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class PlayerAttackingState: PlayerState
{
    public PlayerAttackingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
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

        playerStateMachine.Player.AnimationPlayer.Play("Attack" + animationDirection);

        if (PlayerMovementHandler.PlayerVelocity == Vector2.Zero)
            ChangeToIdling();
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
    }
}
