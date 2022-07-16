using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int health = 5;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int keys = 0; //  пока не надо

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;
            if(Input.GetKey("r"))
            {
            Dice.rolling = true;
        }

    }
}
