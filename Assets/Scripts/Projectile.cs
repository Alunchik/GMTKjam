using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rb;
    public bool enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,10f);
    }
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!enemy && (other.CompareTag("Player") || other.CompareTag("Finish")))
            return;
        if(enemy &&(other.CompareTag("Enemy") || other.CompareTag("Finish")))
            return;
        Destroy(gameObject);
    }
}
