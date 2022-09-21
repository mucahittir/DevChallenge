using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    public void Initialize()
    {
        setDefaults();
        
    }
    public void StartGame()
    {
        setAnimation(PlayerState.Run);
        for(int i= 0; i < 10; i++)
            PoolManager.Instance.SetActiveItemWithPosition("cube", transform.position);
    }

    public void Reload()
    {
        setDefaults();
    }

    public void GameOver()
    {
        setAnimation(PlayerState.Dance);
    }
    public void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0,0,0);
    }
    private void setDefaults()
    {
        setAnimation(PlayerState.Idle);
        transform.position = new Vector3(0, 0, 0);
    }

    private void setAnimation(PlayerState state)
    {
        animator.SetInteger("State", (int)state);

    }

}

public enum PlayerState
{
    Idle,
    Run,
    Dance
}