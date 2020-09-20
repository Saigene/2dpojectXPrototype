using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCombat2 : MonoBehaviour
{

    public Animator animator;
    public int noofClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noofClicks = 0;
        }

        if(CrossPlatformInputManager.GetButtonDown("Fire1"))
        //if (Input.GetKeyDown(KeyCode.F))
        {
            lastClickedTime = Time.time;
            noofClicks++;
            if (noofClicks == 1)
            {
                animator.SetBool("Isjumping", false);
                animator.SetBool("Attack1", true);
            }
            noofClicks = Mathf.Clamp(noofClicks, 0, 3);
        }
    }

    public void return1()
    {

        Debug.Log("attack2");
        if (noofClicks >= 2)
        {
               animator.SetBool("Attack2", true);
          //  animator.SetTrigger("attack2");
        }
        else
        {
            Debug.Log("attack1 false");
            animator.SetBool("Attack1", false);
            noofClicks = 0;
        }
    }

    public void return2()
    {
        if (noofClicks >= 3)
        {
            animator.SetBool("Attack3", true);
        }
        else
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            noofClicks = 0;
        }
    }
    public void return3()
    { 
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
            noofClicks = 0;
        
    }
}
