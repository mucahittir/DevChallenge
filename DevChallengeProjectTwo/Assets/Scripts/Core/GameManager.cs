using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CoreObj<GameManager>
{
    [SerializeField] GameCoordinator gameCoordinator;
    public GameState gameState;
    public override void Initialize()
    {
        setIdleState();
        gameCoordinator.Initialize();
    }

    public void StartGame()
    {
        setInGameState();
        gameCoordinator.StartGame();
    }

    public void Reload()
    {
        setIdleState();
        gameCoordinator.Reload();
    }

    public void GameOver()
    {
        setGameOverState();
        gameCoordinator.GameOver();
    }

    private void setIdleState()
    {
        gameState = GameState.Idle;
        ViewManager.Instance.OpenUIClean("IdleScreen");
    }

    private void setInGameState()
    {
        gameState = GameState.InGame;
        ViewManager.Instance.OpenUIClean("GameplayScreen");
    }

    private void setGameOverState()
    {
        gameState = GameState.GameOver;
        ViewManager.Instance.OpenUIClean("FailScreen");
    }
}
public enum GameState : int
{
    Idle = 0,
    InGame = 1,
    GameOver = 2
}