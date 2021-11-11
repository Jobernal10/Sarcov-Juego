using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sart_fall : MonoBehaviour
{
    public GameObject OBJ;
    public float delay = 1.5f;
    public GameObject pos;
    private int toco;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toco += 1;
            if (toco == 1)
            {
                GameObject cae = Instantiate(OBJ);
                cae.transform.position = pos.transform.position;
            }
            
        }
    }

}
