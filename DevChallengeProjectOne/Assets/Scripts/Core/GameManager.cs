using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    void Start()
    {
        gridManager.Initialize();
    }

}
