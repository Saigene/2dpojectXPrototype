using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    bool comboPossible;
    int comboStep;


    private void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Debug.Log("attacking");
            animator.SetBool("Isjumping", false);
            animator.SetTrigger("Attack1");
        //    Attack();
        }
    }
   

    public void Attack()
    {
        if (comboStep == 0)
        {
            animator.SetTrigger("Attack1");
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }
    public void Combo()
    {
        if (comboStep == 2)
        {
            animator.Play("attack_2",-1);
        }
        if (comboStep == 3)
        {
            animator.Play("attack_3",-1);
        }
    }
    public void ComboReset()
    {
        comboPossible = false;
        comboStep = 0;
    }
       
}
