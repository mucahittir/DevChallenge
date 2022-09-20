using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public Color color;
    public TileState state;
    public int x, y;
    public bool isChecked;
    public SpriteRenderer xSymbol;
    public event Action<Tile> CheckNodes;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isChecked)
        {
            SetChecked(true);
            CheckNodes(this);
        }
    }

    public void SetChecked(bool isChecked)
    {
        this.isChecked = isChecked;
        xSymbol.enabled = isChecked;
    }
}
