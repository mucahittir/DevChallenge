using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] GameObject tileObject;
    [SerializeField] Color color1, color2;
    [SerializeField] int dimension;
    private int width, height;
    private float scale, startX, startY;
    private Vector2 left, right;
    private List<List<Tile>> gridList;

    public void Initialize()
    {
        gridList = new List<List<Tile>>();
        calculatePlacementsAndScale();
        CreateGrid(dimension);
    }

    public void CreateGrid(int dimension)
    {
        width = dimension;
        height = dimension;
        int i = 1;
        for (int x = 0; x < width; x++)
        {
            gridList.Add(new List<Tile>());
            for (int y = 0; y < height; y++)
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
                i++;
                tile.transform.SetParent(transform);
                gridList[x].Add(tile);
                Debug.Log(tile.x + " " + tile.y);
            }
        }
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
}

public enum TileState : int
{
    visited = 0,
    unVisited = 1
}
