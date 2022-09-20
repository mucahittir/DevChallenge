using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject tileObject;
    [SerializeField] Color color1, color2;
    [SerializeField] int dimension;
    private int width, height, matchCount;
    private float scale, startX, startY;
    private Vector2 left, right;
    private List<List<Tile>> gridList;
    private Tile lastClickedTile;

    public Action<int> SetMatchCount;

    public void Initialize(int dimension)
    {
        gridList = new List<List<Tile>>();
        this.dimension = dimension;
        CreateGrid(dimension);
    }

    public void CreateGrid(int dimension)
    {
        calculatePlacementsAndScale();
        width = dimension;
        height = dimension;
        int i = 1;
        for (int y = 0; y < height; y++)
        {
            gridList.Add(new List<Tile>());
            for (int x = 0; x < width; x++)
            {
                Tile tile = Instantiate(tileObject).GetComponent<Tile>();
                tile.color = ((x + y) % 2 == 0) ? color1 : color2;
                tile.state = TileState.unVisited;
                tile.GetComponent<SpriteRenderer>().color = tile.color;
                tile.x = x;
                tile.y = y;
                tile.transform.localScale = new Vector3(scale,scale,scale);
                tile.transform.position = new Vector2(startX + (tile.x * scale), startY + (tile.y * -scale));
                tile.SetChecked(false);
                tile.gameObject.name = "Tile" + i;
                tile.CheckNodes += checkNodes;
                i++;
                tile.transform.SetParent(transform);
                gridList[y].Add(tile);
            }
        }
    }

    public void Rebuild(int dimension)
    {
        matchCount = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridList[x][y].CheckNodes -= checkNodes;
                Destroy(gridList[x][y].gameObject);
            }
        }
        gridList.Clear();
        this.dimension = dimension;
        CreateGrid(dimension);
    }

    
    private void calculatePlacementsAndScale()
    {
        Camera mainCamera = Camera.main;
        left = mainCamera.ScreenToWorldPoint(new Vector3(0, mainCamera.pixelHeight));
        right = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight));
        float xWidth = right.x - left.x;
        scale = xWidth / (float)dimension;
        startX = left.x + (scale / 2);
        startY = right.y - (scale / 2);
        
    }

    private void checkNodes(Tile newTile)
    {
        lastClickedTile = newTile;
        List<Tile> dfsList = new List<Tile>();
        lastClickedTile.state = TileState.visited;
        dfsList.Add(lastClickedTile);
        int counter = 0;

        while(counter < dfsList.Count)
        {
            List<Tile> adjacent = new List<Tile>();
            adjacent.AddRange(getAdjacent(dfsList[counter]));

            foreach(Tile myTile in adjacent)
            {
                if(myTile.state == TileState.unVisited && myTile.isChecked)
                {
                    myTile.state = TileState.visited;
                    dfsList.Add(myTile);
                }
            }
            counter++;
        }

        resetStates();

        if(dfsList.Count >= 3)
        {
            for(int i = 0; i < dfsList.Count; i++)
            {
                dfsList[i].SetChecked(false);
            }
            matchCount++;
            SetMatchCount(matchCount);
        }


    }

    private List<Tile> getAdjacent(Tile tile)
    {
        List<Tile> adjacents = new List<Tile>();

        List<Tile> myLine = gridList[tile.y];
        List<Tile> upLine = null, downLine = null;


        if(tile.y - 1 >= 0)
        {
            upLine = gridList[tile.y - 1];
        }

        if (tile.y + 1 < gridList.Count)
        {
            downLine = gridList[tile.y + 1];
        }


        //side adjacents
        if (tile.x - 1 >= 0)
            adjacents.Add(myLine[tile.x - 1]);

        if (tile.x + 1 < myLine.Count)
            adjacents.Add(myLine[tile.x + 1]);

        //upAdjectent
        if(upLine != null)
        {
            adjacents.Add(upLine[tile.x]);
        }

        //downAdjectent
        if(downLine != null)
        {
            adjacents.Add(downLine[tile.x]);
        }


        return adjacents;
    }

    private void resetStates()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                gridList[x][y].state = TileState.unVisited;
            }
        }
    }
}

public enum TileState : int
{
    visited = 0,
    unVisited = 1
}
