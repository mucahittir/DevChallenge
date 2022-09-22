using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] bool IsActive;
    [SerializeField] float stackOffset, tolerationOffset;
    List<GameStack> stacks;
    GameStack currentStack, movingStack;
    public void Initialize()
    {
        IsActive = false;
        stacks = new List<GameStack>();
        currentStack = LevelController.currentLevel.startingPlatform;
        currentStack.IsLast = true;
        movingStack = null;
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
            stacks[i].Dismiss();
        }
        stacks.Clear();

        currentStack = LevelController.currentLevel.startingPlatform;
        currentStack.IsLast = true;
        movingStack = null;
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
