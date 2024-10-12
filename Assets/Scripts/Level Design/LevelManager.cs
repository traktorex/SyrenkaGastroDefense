using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform start;
    public Transform[] path;

    public int currency;
    public int numberOfWaves = 8;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void GetGold(int amount)
    {
        currency += amount;
    }

    public bool GetBroke(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }

        else
        {
            Debug.Log("Not enough moonies!");
            return false;
        }
        
    }
}
