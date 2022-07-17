using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Saw : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minAngularSpeed;
    [SerializeField] private float maxAngularSpeed;
    [SerializeField] private float safeZone;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private float angularSpeed;
    private float speed;
    void Start()
    {
        var player = GameObject.Find("Player").transform;
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        while ((spawnPos - player.position).magnitude < safeZone)
        {
            spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        }

        transform.position = spawnPos;
        speed = Random.Range(minSpeed, maxSpeed + 1.5f * Player.lvl);
        angularSpeed = Random.Range(minAngularSpeed, maxAngularSpeed);
        rb = GetComponent<Rigidbody2D>();
        moveDir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized * speed;
    }
    
    void Update()
    {
        rb.velocity = moveDir;
        rb.angularVelocity = angularSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        var player = col.GetComponent<Player>();
        var enemy = col.gameObject.GetComponent<EnemyHPSystem>();
        if (player)
        {
            player.health--;
        }
        else if (enemy)
        {
            enemy.TakeDamage(4f);
        }
        
        float angle = Random.Range(150f, 210);
        moveDir = Quaternion.Euler(0f,0f, angle) * moveDir;
    }
}
