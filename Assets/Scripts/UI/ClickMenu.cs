using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;

    private bool isMenuOpen = false;

    public void Open()
    {
        if (isMenuOpen == false)
        {
            isMenuOpen = true;
            animator.SetBool("MenuOpen", true);
        }

        else
        {
            isMenuOpen = false;
            animator.SetBool("MenuOpen", false);
        }
    }

   
}
