using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : CoreObj<PoolManager>
{
    List<PoolDynamic> poolDynamics;

    public override void Initialize()
    {
        poolDynamics = new List<PoolDynamic>();

        foreach(Transform child in transform)
        {
            PoolDynamic childPD = child.GetComponent<PoolDynamic>();
            poolDynamics.Add(childPD);
            childPD.Initialize();
        }
    }

    public PoolObject GetItem(string tag)
    {
        PoolDynamic pool = poolDynamics.Find(x => x.PoolTag == tag);
        return pool.GetItem();
    }

    public void SetActiveItemWithPosition(string tag, Vector3 position)
    {
        PoolDynamic pool = poolDynamics.Find(x => x.PoolTag == tag);
        PoolObject poolObj =  pool.GetItem();
        poolObj.transform.position = position;
        poolObj.SetActive();
    }
    public void SetActiveItemWithTransform(string tag, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        PoolDynamic pool = poolDynamics.Find(x => x.PoolTag == tag);
        PoolObject poolObj = pool.GetItem();
        poolObj.transform.position = position;
        poolObj.transform.rotation = rotation;
        poolObj.transform.localScale = scale;
        poolObj.SetActive();
    }
}
