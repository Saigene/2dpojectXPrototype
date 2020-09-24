using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy2 : MonoBehaviour
{
    public float distance;
    public float speed;
    private bool movingRight = false;
    public Transform groundDetection;
    public Animator animator;

    public void checkgroundinfo()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundinfo.collider == false)
        {
            animator.SetBool("Raycast", true);            
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    public void Holdidle()
    {
        Invoke("Delay2sec", 4f);
    }

    void Delay2sec()
    {
        Debug.Log("Waiting");
        animator.SetBool("Raycast", false);
        if (movingRight == false)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = false;
        }
    }
}
