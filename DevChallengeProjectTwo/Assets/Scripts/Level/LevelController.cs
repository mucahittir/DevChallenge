using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] LevelData levels;
    Level currentLevel;
    public void Initialize()
    {
        loadLevel();
    }

    public void Reload()          
    {
        clearLevel();
        loadLevel();
    }

    private void loadLevel()
    {        
        int currentLevelIndex = (DataManager.Instance.Level - 1) % levels.Count;
        currentLevel = levels[currentLevelIndex];
        currentLevel.LoadLevel();
    }

    private void clearLevel()
    {
        currentLevel.ClearLevel();
    }
}
