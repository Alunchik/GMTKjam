using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public static int lvl = 0;
    public static int keysRequired = 1;
    public int health = 5;
    public int damage = 1;
    public int keys = 0; //  ���� �� ����
    private GameObject animatedPlayer;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Text lvltext;
    private Text goaltext;

    public GameObject hint;
    public GameObject lvlTextObj;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lvltext = lvlTextObj.GetComponent<Text>();
        animatedPlayer = transform.GetChild(0).gameObject;
        animator = animatedPlayer.GetComponent<Animator>();
        if (lvl == 0)
        {
            hint.SetActive(true);
            lvltext.enabled = false;
        }
        else
        {
            hint.SetActive(false);
            lvltext.enabled = true;
            lvltext.text = "LVL" + lvl;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        var projectile = col.gameObject.GetComponent<Projectile>();
        if (projectile && projectile.enemy)
        {
            health -= (int)projectile.damage;
        }

        if (col.CompareTag("Door") && keys >= keysRequired) // переход на след. уровень
        { 
        keys = 0;
        lvl += 1;
        switch (lvl) // расчет кол-ва требуемых ключей на следующем уровне
        {
            case 3:
                keysRequired += 1;
                break;
            case 5:
                keysRequired += 1;
                break;
            case 7:
                keysRequired += 1;
                break;
            default:
                break;
        }
        Scene scene = SceneManager.GetActiveScene(); // перезапускаем текущую сцену
        SceneManager.LoadScene(scene.name);
            }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }
}
