using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem_invisible : MonoBehaviour
{
    public float visionRadius;
    public float speed;
    public int daño;

    GameObject player;
    Animator ani;

    Vector3 initialPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            ani.SetBool("aprece", true);
            Invoke("atacar", 1.3f);
        }
    }

    void atacar()
    {
        Vector3 target = initialPosition;
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < visionRadius)
        { 
            target = player.transform.position; 

        }
        else
        {
            ani.SetBool("aprece", false);
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
