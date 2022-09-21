using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : CoreObj<DataManager>
{

    private int level = 1;
    private int money = 0;

    public int Level { get => level; set => level = value; }
    public int Money { get => money; set => money = value; }

    public override void Initialize()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", level);
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", money);
        }

    }

    public void Save()
    {
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Money", money);
    }
}
