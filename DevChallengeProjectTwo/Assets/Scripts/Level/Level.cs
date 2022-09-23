using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level 
{
    [SerializeField] int levelLength;
    [SerializeField] Transform stackExample;
    List<PoolObject> levelObjects;

    public GameStack startingPlatform;

    public int LevelLength { get => levelLength; set => levelLength = value; }

    public void LoadLevel()
    {
        levelObjects = new List<PoolObject>();
        setStartingBoard();
        setFinisher();
        Debug.Log("Level loaded");
    }

    public void ClearLevel()
    {
        for(int i = 0; i< levelObjects.Count; i++)
        {
            levelObjects[i].Dismiss();
        }
        levelObjects.Clear();
        levelObjects = null;
        Debug.Log("Level cleared");
    }
    private void setStartingBoard()
    {

        GameStack startingPlatform = PoolManager.Instance.GetItem("StartingPlatform") as GameStack;
        startingPlatform.SetActiveWithPosition(new Vector3(0, -0.5f, 0));
        this.startingPlatform = startingPlatform;
        levelObjects.Add(startingPlatform);
    }

    private void setFinisher()
    {
        PoolObject finisher = PoolManager.Instance.GetItem("Finisher");
        float roadEnd = (levelLength * stackExample.localScale.z) + (stackExample.localScale.z / 2f);
        finisher.SetActiveWithPosition(new Vector3(0,0,roadEnd));
        levelObjects.Add(finisher); 
    }
}
