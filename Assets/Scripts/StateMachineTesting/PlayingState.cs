using RayWenderlich.Unity.StatePatternInUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : State
{
    public PlayingState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("game started...");
        SetTimeScaleToOne();
    }

    public override void Exit()
    {

    }

    public override void HandleInput() //input
    {
        Debug.Log("Switching to paused state");
        if (Input.GetButtonDown("Cancel"))
        {
            this.stateMachine.ChangeState(gameManager.PausedState);
        }
    }

    public override void LogicUpdate() //calculations
    {
        if (Base.CurrentHealth <= 0)
        {
            this.stateMachine.ChangeState(gameManager.GameOverState);
        }
    }

    public override void PhysicsUpdate() //Rigidbodies
    {

    }

    private void SetTimeScaleToOne()
    {
        Time.timeScale = 1f;
    }
}
