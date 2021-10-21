using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_managment : MonoBehaviour
{
    public static combat_managment instance; 

    public bool canReceiveInput;
    public bool inputREcieve;
    public Transform attackpoint;
    public float attackrange; 
    public LayerMask enemyLayers; 
    public int Daño_Golpe;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
      if (Input.GetButtonDown("Fire1"))
        {  
            Attack();
        }
    }

    public void Attack()
    {
            if (canReceiveInput)
            {
                inputREcieve = true;
                canReceiveInput = false;
            }
            else
            {
                canReceiveInput = true;
            }    
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemyLayers);

        foreach (Collider2D  enemy in hitEnemies)
        {
            Debug.Log("le pego a " + enemy.name);
            Enemigo_toxico toxico = enemy.GetComponent<Enemigo_toxico>();
            if (toxico != null)
            {
                toxico.HitT(enemy,Daño_Golpe);
            }
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
    
    private void OnDrawGizmos(){
        if (attackpoint == null)
        {
            return;
        }
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackpoint.position,attackrange);
      
    }
}
