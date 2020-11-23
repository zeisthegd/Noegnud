using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

abstract class PlayerState
{
    protected PlayerStateMachine playerStateMachine;
    protected string animationDirection;
    protected PlayerState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        animationDirection = AnimationDirectionController.GetCurrentMovingDirection();
    }


    public abstract void HandleKeypressEvent();

    public virtual void PressDown()
    {
        
    }

    public virtual void PressLeft()
    {
        
    }

    public virtual void PressRight()
    {
        
    }

    public virtual void PressUp()
    {
        
    }
    public virtual void PressAttack()
    {
        if(Input.IsActionJustPressed("attack"))
            ChangeToAttacking();
    }
    public virtual void PlayAnimation()
    {
        animationDirection = AnimationDirectionController.GetCurrentMovingDirection();
    }
    public void ChangeToIdling()
    {
        playerStateMachine.CurrentState = playerStateMachine.PlayerIdlingState;
    }

    public void ChangeToRunning()
    {
        playerStateMachine.CurrentState = playerStateMachine.PlayerRunningState;
    }
    public void ChangeToAttacking()
    {
        playerStateMachine.Player.PlayerSFX.PlaySwipeSFX();
        playerStateMachine.CurrentState = playerStateMachine.PlayerAttackingState;
    }
}
