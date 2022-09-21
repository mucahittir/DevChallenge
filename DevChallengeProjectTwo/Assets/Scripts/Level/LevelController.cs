using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<Level> levels;
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
        Level level = levels[currentLevelIndex];
        currentLevel = level;
        currentLevel.LoadLevel();
    }

    private void clearLevel()
    {
        currentLevel.ClearLevel();
    }
}
