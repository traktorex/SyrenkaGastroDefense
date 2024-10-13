using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndLevel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject EndPoint;

    [Header("Attributes")]
    [SerializeField] public static int HP = 3;
    [SerializeField]

    public bool isEnemy = true;
    private void Start()
    {
        
    }

    public static void LoseHP()
    {
     
        if (HP > 1)
        {
            HP--;
        }

        else
        {
            Time.timeScale = 0f;
            UIManager.OpenLevelEndPanel();
        }
    }

    
}
