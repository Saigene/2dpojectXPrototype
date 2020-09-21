using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Playermovement : MonoBehaviour
{

    public CharacterController2D controller;
    public PlayerCombat3 combat3;
    public Animator animator;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool attacking = false;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
          
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Isjumping", true);
        }


        if (CrossPlatformInputManager.GetButtonDown("Guard"))
        {
            animator.SetBool("Isguard", true);
            animator.SetBool("Isjumping", false);
            crouch = true;
        }
        else if (CrossPlatformInputManager.GetButtonUp("Guard"))
        {
            animator.SetBool("Isguard", false);
            crouch = false;          
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Debug.Log("attacking");
            combat3.Attack();
            animator.SetBool("Isjumping", false); 
        }


        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    } 

    public void OnLanding()
    {
        animator.SetBool("Isjumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if (collision.name == "Coin")
        {
            Debug.Log("Win");
        }
    }


}
