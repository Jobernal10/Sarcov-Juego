using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos_fall : MonoBehaviour
{

    public int damage;
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        //if (other.collider.CompareTag("Player"))
        //{
            Movimiento lily = other.collider.GetComponent<Movimiento>();
            
            if (lily != null)
            {
                Debug.Log("toco");
                lily.Hit(other.collider,damage);
            }
        //}
    }


}
