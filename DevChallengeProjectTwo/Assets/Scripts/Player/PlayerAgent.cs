using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] float speed;
    public void Initialize()
    {
        Debug.Log("Player Initialized");
    }
    public void StartGame()
    {
        Debug.Log("Player Started");
    }

    public void Reload()
    {
        setDefaults();
    }

    public void GameOver()
    {
        Debug.Log("Game over");
    }
    public void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void setDefaults()
    {
        transform.position = new Vector3(0, 0, 0);
    }

}
