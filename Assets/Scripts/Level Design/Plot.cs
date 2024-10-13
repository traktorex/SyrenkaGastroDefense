using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hovercolor;
    [SerializeField] SpriteRenderer ringRenderer;
    [SerializeField] bool usable = false;

    private GameObject tower;
    private Color startColor;
    private float ringRange;

    private void Start()
    {
        startColor = sr.color;
        ringRenderer.enabled = false;
    }

    private void OnMouseEnter()
    {
        sr.color = hovercolor;

        if (usable && tower == null)
        {
            ringRenderer.enabled = true;

            ringRange = BuildingManager.main.GetSelectedTower().prefab.GetComponent<Turrets>().targetingRange;
            ringRenderer.transform.localScale =
                new Vector3(0.1f * ringRange / 40.0f,
                0.1f * ringRange / 40.0f,
                ringRenderer.transform.localScale.z);
        } else if (usable && tower != null)
        {
            ringRenderer.enabled = true;

            ringRange = tower.GetComponent<Turrets>().targetingRange;
            ringRenderer.transform.localScale =
                new Vector3(0.1f * ringRange / 40.0f,
                0.1f * ringRange / 40.0f,
                ringRenderer.transform.localScale.z);
        }
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
        ringRenderer.enabled = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("Build tower here: " + name);
        if (tower != null) return;

        Tower towerToBuild = BuildingManager.main.GetSelectedTower();

        Debug.Log(BuildingManager.main.GetSelectedTower().prefab);

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("Can't afford this");
            return;
        }

        LevelManager.main.GetBroke(towerToBuild.cost);

        BuildingManager.main.GetSelectedTower().prefab.GetComponent<Turrets>().layerOrder 
            = this.sr.sortingOrder + 1;
        BuildingManager.main.GetSelectedTower().prefab.GetComponent<Turrets>().sortingLayerID
            = this.sr.sortingLayerID;

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
