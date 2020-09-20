using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat3 : MonoBehaviour
{
    public static PlayerCombat3 instance;
    public bool canReceiveInput;
    public bool inputReceived;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inputReceived = true;
            canReceiveInput = false;
        }
        else
        {
            return;
        }
    }

    public void InputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }
}
