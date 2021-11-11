using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil_flema : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    public int daño;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        if (direction.x < 0)
        {
             transform.localScale = new Vector3(-0.2783f, 0.2783f, 0.2783f);
        }
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Movimiento lily = other.GetComponent<Movimiento>();
        if (lily != null)
        {
            lily.Hit(other,daño);
            DestroyBullet();
        }
        
    }
}
