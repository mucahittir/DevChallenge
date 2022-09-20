using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] InputField inputField;
    void Start()
    {
        int dimension = 0;
        int.TryParse(inputField.text, out dimension);
        gridManager.Initialize(dimension);
    }

    public void Rebuild()
    {
        int dimension = 0;
        int.TryParse(inputField.text, out dimension);
        gridManager.Rebuild(dimension);
    }

}
