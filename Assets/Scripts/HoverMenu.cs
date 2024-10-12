using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator animator;

    private bool isMenuOpen = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMenuOpen = true;
        animator.SetBool("MenuOpen", true);
        Debug.Log("OnMouseOpen");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMenuOpen = false;
        animator.SetBool("MenuOpen", false);
        Debug.Log("OnMouseExit");
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }

   
    

}
