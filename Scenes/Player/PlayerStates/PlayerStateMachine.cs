using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerStateMachine
{
    Player player;

    #region States

    PlayerState currentState;

    PlayerState playerRunningState;
    PlayerState playerIdlingState;
    PlayerState playerAttackingState;


    #endregion

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        playerIdlingState = new PlayerIdlingState(this);
        playerRunningState = new PlayerRunningState(this);
        playerAttackingState = new PlayerAttackingState(this);

        currentState = playerIdlingState;
    }

    public void HandleKeypressEvent()
    {
        currentState.HandleKeypressEvent();
    }

    public void AttackAnimationFinished()
    {
        currentState.ChangeToIdling();
    }


    internal PlayerState CurrentState {set => currentState = value; }
    internal PlayerState PlayerRunningState { get => playerRunningState; }
    internal PlayerState PlayerIdlingState { get => playerIdlingState; }
    internal PlayerState PlayerAttackingState { get => playerAttackingState; }

    public Player Player { get => player; }
    

}
