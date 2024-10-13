using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Level Results")]
    [SerializeField] GameObject zwyciêstwo;
    [SerializeField] GameObject pora¿ka;
    [SerializeField] GameObject levelEndPanel;

    [Header("Enemy Path")]
    public Transform start;
    public Transform[] path;

    public int currency;
    public int numberOfWaves = 8;
    public bool isWinning = false;

    private int currentWave;


    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
        zwyciêstwo.SetActive(false);
        pora¿ka.SetActive(false);
        levelEndPanel.SetActive(false);
    }

    private void Update()
    {
        SetCurrentWave();

        if (currentWave == 8) 
        {
            EndGame();
        }
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
            return false;
        }
        
    }

    public void EndGame()
    {
        
        if (currentWave == 8 && currency >= 3500)
        {
            isWinning = true;
        }

        if (currentWave == 8 && currency < 3500)
        {
            isWinning = false;
        }

        EndScreen();
    }

    private void EndScreen()
    {
        Time.timeScale = 0;
        levelEndPanel.SetActive(true);
        if (isWinning == true)
        {
            zwyciêstwo.SetActive(true);
        }

        else
        {
            pora¿ka.SetActive(true);
        }
    }

    private void SetCurrentWave()
    {
        currentWave = EnemySpawner.currentWave;
    }
}
