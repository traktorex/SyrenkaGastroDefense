using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullets
{
    [SerializeField] public float enemySlowdownRatio = 0.5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyMovement>().SlowDown(enemySlowdownRatio);
        base.OnCollisionEnter2D(other);
    }
}
