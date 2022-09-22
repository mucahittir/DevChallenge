using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData",menuName ="LevelData", order = 99)]
public class LevelData : ScriptableObject
{
    [SerializeField] List<Level> levels;
    public Level this[int i] => levels[i];
    public int Count => levels.Count;
}
