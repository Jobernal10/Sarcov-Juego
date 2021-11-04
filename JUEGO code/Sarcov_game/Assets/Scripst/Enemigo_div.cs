using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_div : MonoBehaviour
{
    public float rangVision;
    public float Cronometro;
    public float Cronometroani;
    public float detenerce;
    public int Tclonacion;
    GameObject player;
    GameObject clon;
    public GameObject clon2;
    Animator ani;
    private bool div;

    public float velocidad;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
         ani = GetComponent<Animator>();
    }
    void IA()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist<rangVision)
        {
            
            Cronometro += 1 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidad * Time.deltaTime);

            if (Cronometro >= Tclonacion)
            {
                Cronometro = 0;
              
                ani.SetBool("div", true);
                Invoke("clonar", 1.4f);
          
                
            }

            

        }
    }

    void clonar()
    {
        clon = Instantiate(clon2);
        clon.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
        ani.SetBool("div", false);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangVision);
        
    }
    void Update()
    {
        IA();
    }
}
