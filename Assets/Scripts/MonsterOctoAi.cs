using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOctoAi : MonoBehaviour
{
    public float speed;
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
}
