using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    List<PoolObject> levelObjects;
    public void LoadLevel()
    {
        levelObjects = new List<PoolObject>();
        setStartingBoard();
        buildRoad();
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

        PoolObject startingPlatform = PoolManager.Instance.GetItem("StartingPlatform");
        startingPlatform.SetActiveWithPosition(new Vector3(0, 0, 0));
        levelObjects.Add(startingPlatform);
    }
    private void buildRoad()
    {

    }
    private void setFinisher()
    {
        PoolObject finisher = PoolManager.Instance.GetItem("Finisher");
        finisher.SetActiveWithPosition(new Vector3(0,0,50));
        levelObjects.Add(finisher); 
    }
}
