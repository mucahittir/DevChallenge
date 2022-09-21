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
}
