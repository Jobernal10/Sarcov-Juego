using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_managment : MonoBehaviour
{
    public static combat_managment instance; 

    public bool canReceiveInput;
    public bool inputREcieve;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Attack(); 
    }

    
    void Update()
    {
      Attack();  
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //if (canReceiveInput)
            //{
                inputREcieve = true;
                canReceiveInput = false;
            //}
            //else
            //{
              //  return;
            //}
            
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
