using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 25;

    private bool isDestroyed = false;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.GetGold(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
