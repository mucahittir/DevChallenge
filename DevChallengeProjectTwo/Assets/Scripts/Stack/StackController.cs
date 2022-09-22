using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] bool IsActive;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float stackOffset, tolerationOffset;
    List<GameStack> stacks;
    GameStack currentStack, movingStack;
    int perfectCount;
    public void Initialize()
    {
        IsActive = false;
        stacks = new List<GameStack>();
        currentStack = LevelController.currentLevel.startingPlatform;
        currentStack.IsLast = true;
        movingStack = null;
        perfectCount = 0;
    }

    public void StartGame()
    {
        IsActive = true;
        setNewStack();
    }

    public void Reload()
    {
        for(int i = 0; i < stacks.Count; i++)
        {
            stacks[i].OnPerfect -= onPerfect;
            stacks[i].Dismiss();
        }
        stacks.Clear();

        currentStack = LevelController.currentLevel.startingPlatform;
        currentStack.IsLast = true;
        movingStack = null;
        perfectCount = 0;
    }

    public void GameOver()
    {
        IsActive = false;
    }

    private void setNewStack()
    {
        if(IsActive)
        {
            bool isSucceed = true;
            if(movingStack != null)
                isSucceed = placeLastStack();


            if (!isSucceed)
                return;

            generateStack();
        }
    }

    private bool placeLastStack()
    {
        bool isSucceed = movingStack.SplitThis(currentStack, tolerationOffset);
        if(!isSucceed)
        {
            GameManager.Instance.GameOver();
            return false;
        }
        else
        {
            currentStack.IsLast = false;
            currentStack = movingStack;
            currentStack.IsLast = true;
            return true;
        }
    }
    private void generateStack()
    {
        if(stacks.Count < LevelController.currentLevel.LevelLength)
        {
            movingStack = PoolManager.Instance.GetItem("Stack") as GameStack;
            movingStack.OnPerfect += onPerfect;
            float stackPosition = (stacks.Count + 1) * stackOffset;
            movingStack.transform.localScale = currentStack.transform.localScale;
            movingStack.SetActiveWithPosition(new Vector3(0, -0.5f, stackPosition));
            stacks.Add(movingStack);
        }
        else
        {
            movingStack = null;
            currentStack.IsEnd = true;
        }
    }

    private void onPerfect(bool isPerfect)
    {
        if(isPerfect)
        {
            perfectCount++;
            audioSource.pitch = 1 + ((perfectCount - 1) * 0.1f);
            audioSource.Play();
        }
        else
        {
            perfectCount = 0;
        }
    }



    private void Update()
    {
        if(IsActive)
        {
            if (movingStack != null)
                movingStack.Move();

            if (Input.GetMouseButtonDown(0))
            {
                setNewStack();
            }
        }
    }
}
