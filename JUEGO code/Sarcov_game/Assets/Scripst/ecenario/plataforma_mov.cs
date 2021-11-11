using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_mov : MonoBehaviour
{
    public GameObject ObjetoaMover;
    public Transform StartPoint; 
    public Transform EndPoint;

    public float Velocidad;

    private Vector3 MoverHacia;

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoaMover.transform.position = Vector3.MoveTowards(ObjetoaMover.transform.position,MoverHacia,Velocidad * Time.deltaTime);

        if (ObjetoaMover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }
        if (ObjetoaMover.transform.position == StartPoint.position)
        {
           MoverHacia = EndPoint.position;
        }


    }

}
