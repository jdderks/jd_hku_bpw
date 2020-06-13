using RayWenderlich.Unity.StatePatternInUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    public GameOverState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameoverScene");
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void HandleInput()
    {

    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }
}
