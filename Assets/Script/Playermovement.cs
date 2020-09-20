﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Playermovement : MonoBehaviour
{

    public CharacterController2D controller;
    public PlayerCombat playercombat;
    public Animator animator;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
          
        if (Input.GetButtonDown("Jump"))
        {

            Debug.Log("Jumping");
            jump = true;
            animator.SetBool("Isjumping", true);
        }




        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
           
        }
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