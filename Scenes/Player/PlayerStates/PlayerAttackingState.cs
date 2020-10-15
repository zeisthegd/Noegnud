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
        PlayAnimation();          
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


    public override void PlayAnimation()
    {
        base.PlayAnimation();
        
        if(!IsPlayingAttackAnimation())
            playerStateMachine.Player.AnimationPlayer.Play("Attack" + animationDirection);
    }

    private bool IsPlayingAttackAnimation()
    {
        return playerStateMachine.Player.AnimationPlayer.CurrentAnimation.StartsWith("Attack");
    }
}
