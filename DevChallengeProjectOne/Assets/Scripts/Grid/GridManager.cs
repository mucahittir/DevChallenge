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
        for (int y = 0; y < height; y++)
        {
            gridList.Add(new List<Tile>());
            for (int x = 0; x < width; x++)
            {
                Tile tile = Instantiate(tileObject).GetComponent<Tile>();
                tile.State = TileState.unVisited;
                tile.SetColor(((x + y) % 2 == 0) ? color1 : color2);
                tile.SetCoordinates(x, y);
                tile.SetScale(scale);
                tile.SetChecked(false);
                tile.transform.position = new Vector2(startX + (tile.X * scale), startY + (tile.Y * -scale));
                tile.transform.SetParent(transform);
                tile.CheckNodes += checkNodes;
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
        lastClickedTile.State = TileState.visited;
        dfsList.Add(lastClickedTile);
        int counter = 0;

        while(counter < dfsList.Count)
        {
            List<Tile> adjacent = new List<Tile>();
            adjacent.AddRange(getAdjacent(dfsList[counter]));

            foreach(Tile myTile in adjacent)
            {
                if(myTile.State == TileState.unVisited && myTile.IsChecked)
                {
                    myTile.State = TileState.visited;
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

        List<Tile> myLine = gridList[tile.Y];
        List<Tile> upLine = null, downLine = null;

        if(tile.Y - 1 >= 0)
        {
            upLine = gridList[tile.Y - 1];
        }

        if (tile.Y + 1 < gridList.Count)
        {
            downLine = gridList[tile.Y + 1];
        }


        //side adjacents
        if (tile.X - 1 >= 0)
            adjacents.Add(myLine[tile.X - 1]);

        if (tile.X + 1 < myLine.Count)
            adjacents.Add(myLine[tile.X + 1]);

        //upAdjectent
        if(upLine != null)
        {
            adjacents.Add(upLine[tile.X]);
        }
        //downAdjectent
        if(downLine != null)
        {
            adjacents.Add(downLine[tile.X]);
        }

        return adjacents;
    }

    private void resetStates()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                gridList[x][y].State = TileState.unVisited;
            }
        }
    }
}

public enum TileState : int
{
    visited = 0,
    unVisited = 1
}
