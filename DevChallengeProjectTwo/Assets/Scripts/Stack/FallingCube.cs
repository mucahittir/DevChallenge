using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : PoolObject
{
    [SerializeField] float dismissTime;
    [SerializeField] Rigidbody rg;
    [SerializeField] MeshRenderer mr;

    public MeshRenderer Mr { get => mr; set => mr = value; }

    public override void SetActive()
    {
        base.SetActive();
        rg.velocity = Vector3.zero;
        StartCoroutine(DismissByTime());
    }

    private IEnumerator DismissByTime()
    {
        yield return new WaitForSeconds(dismissTime);
        Dismiss();
    }
}
