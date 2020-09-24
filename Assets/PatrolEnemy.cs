using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float distance;
    public float speed;
    private bool movingRight = false;
    public Transform groundDetection;
  //  bool checkraycast = false;
    public Animator animator;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
       
      
        if (groundinfo.collider == false)
        {
            animator.SetBool("Raycast", true);
          
            if (i == 3)
            {          
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

            StartCoroutine(delay3sec());

        }
        else
        {
            animator.SetBool("Raycast", false);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator delay3sec()
    {
        yield return new WaitForSeconds(3f);
        i += 1;
        Debug.Log(i);
        if (i == 3)
        {
            i = 0;
        }
    }


}
