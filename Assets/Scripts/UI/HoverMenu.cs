using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
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

    public void ButtonSpriteChange()
    {

    }

   
    

}
