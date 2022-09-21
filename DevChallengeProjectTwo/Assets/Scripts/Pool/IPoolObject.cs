using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject 
{
    public bool IsActive { get; set; }
    public abstract void SetActive();

    public abstract void Dismiss();
}
