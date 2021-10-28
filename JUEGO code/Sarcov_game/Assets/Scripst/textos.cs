using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textos : MonoBehaviour
{
    public GameObject texto;
    public GameObject ubicacion;
  
    private void OnTriggerEnter2D(Collider2D other){
       
       if (texto)
        {
        GameObject textot = Instantiate(texto);
        textot.transform.position = new Vector3(ubicacion.gameObject.transform.position.x,ubicacion.gameObject.transform.position.y,ubicacion.gameObject.transform.position.z);
   
        }  
    }
}
