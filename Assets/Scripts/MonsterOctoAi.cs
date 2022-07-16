using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOctoAi : MonoBehaviour
{
    public float speed;
    public float hp;
    private GameObject player;
    private Rigidbody2D rb;
    
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.left,
            player.transform.position - transform.position , Vector3.forward));
        rb.velocity = -transform.right * speed;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {

        var projectile = other.GetComponent<Projectile>();
        if (projectile)
        {
            
        }
        
    }*/
}
