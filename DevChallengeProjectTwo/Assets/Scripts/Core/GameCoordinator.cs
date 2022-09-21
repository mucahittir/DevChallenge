using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] LevelController levelController;
    public void Initialize()
    {
        levelController.Initialize();
        playerController.Initialize();
        playerController.IsActive = false;
    }
    public void StartGame()
    {
        playerController.StartGame();
        playerController.IsActive = true;
    }
    public void Reload()
    {
        levelController.Reload();
        playerController.Reload();
        playerController.IsActive = false;
    }

    public void GameOver()
    {
        playerController.GameOver();
        playerController.IsActive = false;
    }

}
