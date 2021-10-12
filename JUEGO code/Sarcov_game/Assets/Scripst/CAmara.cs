using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmara : MonoBehaviour
{
    public Transform lily;

  
    void Update()
    {
        if (lily != null)
        {
             Vector3 position = transform.position;
            position.x = lily.position.x;
            transform.position = position;
        }
        
    }
}
