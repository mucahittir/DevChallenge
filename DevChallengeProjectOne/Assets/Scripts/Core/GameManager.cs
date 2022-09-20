using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] InputField inputField;
    [SerializeField] Text matchCountText;
    void Start()
    {
        int dimension = 0;
        int.TryParse(inputField.text, out dimension);
        gridManager.SetMatchCount = OnMatch;
        gridManager.Initialize(dimension);
        setMatchCountText(dimension);

    }

    public void Rebuild()
    {
        int dimension = 0;
        int.TryParse(inputField.text, out dimension);
        gridManager.Rebuild(dimension);
        setMatchCountText(dimension);
    }

    public void OnMatch(int matchCount)
    {
        setMatchCountText(matchCount);
    }

    private void setMatchCountText(int match)
    {
        matchCountText.text = "Match Count: " + match;
    }


}
