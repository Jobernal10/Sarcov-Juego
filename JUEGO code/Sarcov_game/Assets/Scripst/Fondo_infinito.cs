using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_infinito : MonoBehaviour
{
    Material mt;
    public float paralax = 2f;
    Transform cam;
    Vector2 offset;

    void Start()
    {
    SpriteRenderer sp = GetComponent<SpriteRenderer>();
    mt = sp.material;   
    cam = Camera.main.transform;
    offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = cam.position.x / transform.localScale.x / paralax;
        offset.y = cam.position.y / transform.localScale.y / paralax;

        mt.mainTextureOffset = offset;
    }
}
