using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int health = 5;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int keys = 0; //  ���� �� ����
    [SerializeField] private GameObject animatedPlayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = animatedPlayer.GetComponent<Animator>();

    }

    private void Update()
    {
        if (rb.velocity.magnitude < 0.1f && animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", false);
        }
        else if (rb.velocity.magnitude > 0.1f && !animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", true);
        }
        
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }
}
