using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    [SerializeField] CoreObj[] coreObjects;

    private void Awake()
    {
        foreach (CoreObj item in coreObjects)
        {
            item.Initialize();
        }
    }
}
