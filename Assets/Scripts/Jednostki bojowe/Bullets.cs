using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullets : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] public float bulletSpeed = 10f;
    [SerializeField] public float bulletDamage = 1;

    public Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Enemy_Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
