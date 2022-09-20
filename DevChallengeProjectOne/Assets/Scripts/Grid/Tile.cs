using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer xSymbol;
    [SerializeField] private SpriteRenderer tileSprite;
    private TileState state;
    private int x,y;
    private bool isChecked;

    public TileState State { get => state; set => state = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public bool IsChecked { get => isChecked; set => isChecked = value; }
    public SpriteRenderer XSymbol { get => xSymbol; set => xSymbol = value; }

    public event Action<Tile> CheckNodes;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!IsChecked)
        {
            SetChecked(true);
            CheckNodes(this);
        }
    }

    public void SetChecked(bool isChecked)
    {
        this.IsChecked = isChecked;
        XSymbol.enabled = isChecked;
    }

    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetColor(Color color)
    {
        tileSprite.color = color;
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale,scale,scale);
    }
}
