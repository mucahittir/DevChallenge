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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isChecked)
        {
            SetChecked(true);
        }
    }

    public void SetChecked(bool isChecked)
    {
        this.isChecked = isChecked;
        xSymbol.enabled = isChecked;
    }
}
