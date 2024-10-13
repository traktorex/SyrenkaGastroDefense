using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turrets : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Attribute")]
    [SerializeField] public float targetingRange = 3.5f;
    [SerializeField] private float bulletsPerSecond = 1f;
    [SerializeField] private float rotationSpeed = 100f;

    [Header("Sounds")]
    [SerializeField] private AudioClip shootSoundClip;
    [SerializeField] private AudioClip shootSoundClip2;

    private Transform target;
    private float timeUntilFire;
    public int layerOrder = 0;
    public int sortingLayerID = 0;
    public bool soundVariation = false;

    private void Start()
    {
        spriteRenderer.sortingOrder = layerOrder;
        spriteRenderer.sortingLayerID = sortingLayerID;
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }

        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bulletsPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }


    private bool CheckBulletType(string name)
    {
        return bulletPrefab.name == name;
    }
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullets bulletScript = bulletObj.GetComponent<Bullets>();
        bulletScript.SetTarget(target);
        Debug.Log("Turret is shooting.");
        AudioSource.PlayClipAtPoint(soundVariation ? shootSoundClip : shootSoundClip2, 
            new Vector3(-960, -540, -10), 0.4f);
        soundVariation = !soundVariation;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
/*    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }*/
}
