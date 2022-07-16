using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public int health = 5;
    public int damage = 1;
    public int keys = 0; //  ���� �� ����
    private GameObject animatedPlayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatedPlayer = transform.GetChild(0).gameObject;
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

        if((Input.GetKey("r")) && (Dice.rolling == false))
        {
            Dice.rolling = true;
        }
        
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }
}
