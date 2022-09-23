using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform model; 
    [SerializeField] float speed;
    public void Initialize()
    {
        setDefaults();
        
    }
    public void StartGame()
    {
        setAnimation(PlayerState.Run);
    }

    public void Reload()
    {
        setDefaults();
    }

    public void GameOver()
    {
        setAnimation(PlayerState.Idle);
    }
    public void GameSuccess()
    {
        setAnimation(PlayerState.Dance);
    }
    public void Movement()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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

    private void moveToCenter(Vector3 position)
    {
        float direction = 0f;
        if (transform.position.x - position.x < 0)
        {
            direction = 1f;
        }
        else if(transform.position.x - position.x > 0)
        {
            direction = -1f;
        }
        float turningAngle = 30 * direction;
        transform.DOMoveX(position.x, 0.2f)
            .OnStart(() => model.DORotateQuaternion(Quaternion.Euler(0, turningAngle, 0), 0.05f))
            .OnComplete(() => model.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.05f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StackControl"))
        {
            GameStack thisStack = other.attachedRigidbody.GetComponent<GameStack>();
            if (thisStack.IsLast && !thisStack.IsEnd)
            {
                GameManager.Instance.GameOver();
            }
        }

        else if (other.CompareTag("Stack"))
        {
            moveToCenter(other.transform.position);
        }

        else if (other.CompareTag("Finisher"))
        {
            GameManager.Instance.GameSuccess();
        }
    }

}

public enum PlayerState
{
    Idle,
    Run,
    Dance
}