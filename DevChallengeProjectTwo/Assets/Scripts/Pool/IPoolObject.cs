using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject 
{
    public bool IsActive { get; set; }
    public abstract void SetActive();

    public abstract void Dismiss();

    public abstract void SetActiveWithPosition(Vector3 position);
    public abstract void SetActiveWithTransform(Vector3 position, Quaternion rotation, Vector3 scale);
}
