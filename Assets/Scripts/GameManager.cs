using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayWenderlich.Unity.StatePatternInUnity;

public class GameManager : MonoBehaviour
{
    private StateMachine fsm;

    private UIManager uiManager;

    private PlayingState playing;
    private PausedState paused;
    private GameOverState gameOver;

    public PlayingState PlayingState { get => playing; }
    public PausedState PausedState { get => paused; }
    public GameOverState GameOverState { get => gameOver; }

    private void Start()
    {

        fsm = new StateMachine();

        playing = new PlayingState(this, fsm);
        paused = new PausedState(this, fsm);
        gameOver = new GameOverState(this, fsm);

        fsm.Initialize(PlayingState);
    }

    private void Update()
    {
        fsm.CurrentState.HandleInput();
        fsm.CurrentState.LogicUpdate();
    }
}
