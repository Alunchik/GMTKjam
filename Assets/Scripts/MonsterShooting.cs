using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private GameObject bulletRef;
    private Transform shootPoint;

    [SerializeField] private float shootDelay;
    void Start()
    {
        InvokeRepeating("Shoot",shootDelay,shootDelay);
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        shootPoint = transform.GetChild(1);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.left,
            player.transform.position - transform.position , Vector3.forward));
        rb.velocity = -transform.right * speed;
        
    }

    void Shoot()
    {
        Instantiate(bulletRef,transform.position,shootPoint.rotation);
        animator.SetTrigger("Shooting");
    }
}
