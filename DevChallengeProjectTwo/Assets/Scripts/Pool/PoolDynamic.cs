using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDynamic : MonoBehaviour
{
    [SerializeField] string poolTag;
    [SerializeField] PoolObject objectToPool;
    [SerializeField] int amount;
    List<PoolObject> objects;

    public string PoolTag { get => poolTag; set => poolTag = value; }

    public void Initialize()
    {
        objects = new List<PoolObject>();

        for (int i = 0; i < amount; i++)
        {
            PoolObject pooledObj = Instantiate(objectToPool, transform);
            pooledObj.Dismiss();
            objects.Add(pooledObj);
        }
    }

    public PoolObject GetItem()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if(!objects[i].IsActive)
            {
                return objects[i];
            }
        }

        PoolObject pooledObj = Instantiate(objectToPool, transform);
        pooledObj.Dismiss();
        objects.Add(pooledObj);
        return pooledObj;
    }

}
