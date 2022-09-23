using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] bool canRun;
    [SerializeField] PlayerAgent player;
    [SerializeField] float defaultSpeed, maxSpeed;

    public bool IsActive { get => isActive; set => isActive = value; }
    public bool CanRun { get => canRun; set => canRun = value; }

    public void Initialize()
    {
        player.Initialize();
        player.SetSpeed(defaultSpeed);
        canRun = false;
    }
    public void StartGame()
    {
        player.StartGame();
    }
    public void Reload()
    {
        player.Reload();
        player.SetSpeed(defaultSpeed);
        canRun = false;
    }
    public void GameOver()
    {
        player.GameOver();
    }
    public void GameSuccess()
    {
        player.GameSuccess();
    }

    public void OnLastPlace()
    {
        player.SetSpeed(maxSpeed);
    }
    public void OnFirstPlace()
    {
        canRun = true;
        player.SetAnimation(PlayerState.Run);
    }

    private void Update()
    {
        if(IsActive && CanRun)
        {
            player.Movement();
        }
    }

}
