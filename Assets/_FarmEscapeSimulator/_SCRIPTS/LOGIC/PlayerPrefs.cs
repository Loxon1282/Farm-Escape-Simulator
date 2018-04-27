using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs
{

    public string name;
    public float record;
    public float coinCount;
    public float diamontsCount;
    public int stage;

    public PlayerPrefs()
    {
        name = "default";
        record = 0;
        coinCount = 0;
        diamontsCount = 0;
        stage = 0;
    }

}
