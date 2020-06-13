using RayWenderlich.Unity.StatePatternInUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedState : State
{
    public PausedState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        UIManager.Instance.TogglePause();
        SetTimeScaleToZero();
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.TogglePause();
    }
    public override void HandleInput()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            this.stateMachine.ChangeState(gameManager.PlayingState);
        }
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }

    private void SetTimeScaleToZero()
    {
        Time.timeScale = 0f;
    }
}
