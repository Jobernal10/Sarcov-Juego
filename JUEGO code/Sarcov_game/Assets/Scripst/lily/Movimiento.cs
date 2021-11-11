using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{

    [SerializeField]Transform spawnPoint;
    public float JumpForce;
    public float Speed;
    private Rigidbody2D Rigidbody2D; 
    private float Horizontal;
    private Animator Animator;
    private bool Grounded = false;
    public int Health;
    public int initial_healt;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
         //Movimiento
          Horizontal = Input.GetAxisRaw("Horizontal");
          Animator.SetBool("run", Horizontal != 0.0f);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Detectar suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.29f))
        {
            Grounded = true;
        }
        else Grounded = false;
        
       Animator.SetBool("jump", Grounded != true);
        //Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded ){
            Jump(); 
        }
    }

    //mecanicas de salto y movimiento 
    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed,Rigidbody2D.velocity.y);

    }

    //daño resivido enemigos
    public void Hit(Collider2D other,int daño)
    {
        Health -= daño;
        if (Health <= 0)
        {

           Destroy(gameObject);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           //other.transform.position = spawnPoint.position;
           //Health = initial_healt;

        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_mov")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_mov")
        {
            transform.parent = null;
        }
    }

}
