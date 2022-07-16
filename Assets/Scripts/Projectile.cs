using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,10f);
    }
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }*/
}
