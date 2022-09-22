using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour, IPoolObject
{
    public bool IsActive { get; set; }
    public virtual void SetActive()
    {
        gameObject.SetActive(true);
        IsActive = true;
    }

    public virtual void Dismiss()
    {
        gameObject.SetActive(false);
        IsActive = false;
    }

    public void SetActiveWithPosition(Vector3 position)
    {
        transform.position = position;
        SetActive();
    }

    public void SetActiveWithTransform(Vector3 position,Quaternion rotation, Vector3 scale)
    {

        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
        SetActive();
    }
}
