using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] PlayerAgent player;

    public bool IsActive { get => isActive; set => isActive = value; }

    public void Initialize()
    {
        player.Initialize();
    }
    public void StartGame()
    {
        player.StartGame();
    }
    public void Reload()
    {
        player.Reload();
    }
    public void GameOver()
    {
        player.GameOver();
    }
    public void GameSuccess()
    {
        player.GameSuccess();
    }

    private void Update()
    {
        if(IsActive)
        {
            player.Movement();
        }
    }

}
