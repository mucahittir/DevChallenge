using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StackController stackController;
    [SerializeField] LevelController levelController;
    [SerializeField] CameraController cameraController; 
    public void Initialize()
    {
        levelController.Initialize();
        playerController.Initialize();
        stackController.Initialize();
        cameraController.Initialize();
        playerController.IsActive = false;
    }
    public void StartGame()
    {
        playerController.StartGame();
        cameraController.StartGame();
        stackController.StartGame();
        playerController.IsActive = true;
    }
    public void Reload()
    {
        levelController.Reload();
        cameraController.Reload();
        playerController.Reload();
        stackController.Reload();
        playerController.IsActive = false;
    }

    public void GameSuccess()
    {

        playerController.GameSuccess();
        cameraController.GameSuccess();
        stackController.GameOver();
        playerController.IsActive = false;
    }

    public void GameOver()
    {
        playerController.GameOver();
        cameraController.GameOver();
        stackController.GameOver();
        playerController.IsActive = false;
    }

}
