using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public void Initialize()
    {
        playerController.IsActive = false;
        playerController.Initialize();
    }
    public void StartGame()
    {
        playerController.IsActive = true;
        playerController.StartGame();
    }
    public void Reload()
    {
        playerController.IsActive = false;
        playerController.Reload();
    }

    public void GameOver()
    {
        playerController.IsActive = false;
        playerController.GameOver();
    }

}
