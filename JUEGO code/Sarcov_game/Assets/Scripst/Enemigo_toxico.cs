using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_toxico : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;

    public int Health;
    private float lastshoot;
    public GameObject Proyectil;
    private float px;

    //private UnityEngine.Object enemyRef;

    void Start()
    {
        //enemyRef = Assets.Load("Enemy");
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void Comportamientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
             cronometro += 1 * Time.deltaTime;
            if(cronometro >= 2)
            {
             //ani.SetBool("Walk", true);
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("Walk", false);
                    break;
            
                case 1:
                    direccion = Random.Range(0,2);
                    rutina++;
                    break;
            
                case 2:
                    switch (direccion)
                    {
                        case 0:    
                            transform.rotation = Quaternion.Euler(0,0,0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0,180,0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("Walk", true);
                    break;
            }
        }
       else
       {
           if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
           {
               if (transform.position.x < target.transform.position.x)
               {
                    ani.SetBool("Walk", true);
                    transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,0,0);
               }
               else
               {
                   ani.SetBool("Walk", true);
                    transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,180,0);
               }
               
           }
           else
           {
               if (!atacando)
               {
                   if (transform.position.x < target.transform.position.x )
                   {
                        transform.rotation = Quaternion.Euler(0,0,0);
                        px = 0.2783f;
                        ani.SetBool("Walk", false);
                   }
                   else
                   {
                       transform.rotation = Quaternion.Euler(0,180,0);
                       px = -0.2783f;
                        ani.SetBool("Walk", false);
                   }
                   if (target.transform.position.x > rango_ataque && Time.time > lastshoot + 3.0f)
                   {
                        ani.SetBool("Walk", false);
                        //Debug.Log("Disparo");
                        Shoot();
                        lastshoot = Time.time;
                   }
                   
               }
           }
       }
    }

    private void Shoot()
    {

            Vector3 directionp = new Vector3(px, 0.0f, 0.0f);
            GameObject bullet = Instantiate(Proyectil, transform.position + directionp * 0.1f, Quaternion.identity);
            bullet.GetComponent<proyectil_flema>().SetDirection(directionp);
    }

    public void HitT(Collider2D other,int daño)
    {
        Health -= daño;
        Debug.Log("Enemigo recibio " + daño + " de daño");
        if (Health <= 0){
           DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,rango_vision);
        Gizmos.DrawWireSphere(transform.position,rango_ataque);
    }
    
    void Update()
    {
       // if (target == null)
        //{
         //   respwan();
       // }
        Comportamientos();
    }
    /*void respwan()
    {
        GameObject enemyclone = (GameObject)Instantiate(enemyRef);
        enemyclone.transform.position = transform.position;
    }*/
}
