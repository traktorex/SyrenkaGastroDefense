using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float hitPoints = 2;
    [SerializeField] private int currencyWorth = 25;

    [Header("Sounds")]
    [SerializeField] private AudioClip shootSoundClip;
    [SerializeField] private AudioClip shootSoundClip2;
    [SerializeField] private AudioClip finishSoundClip;

    public bool soundVariation = false;
    private bool isDestroyed = false;
    public void TakeDamage(float dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.GetGold(currencyWorth);
            isDestroyed = true;
            AudioSource.PlayClipAtPoint(finishSoundClip,
                new Vector3(-960, -540, -10), 0.4f);
            Destroy(gameObject);
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundVariation ? shootSoundClip : shootSoundClip2,
                new Vector3(-960, -540, -10), 0.4f);
            soundVariation = !soundVariation;
        }
    }

}
