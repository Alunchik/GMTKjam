
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trap : MonoBehaviour
{

    [SerializeField] private float safeZone;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private void Start()
    {
        var player = GameObject.Find("Player").transform;
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        while ((spawnPos - player.position).magnitude < safeZone)
        {
            spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        }
        transform.position = spawnPos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<Player>();
        var enemy = col.gameObject.GetComponent<EnemyHPSystem>();
        if (player)
        {
            player.health--;
            var fj = gameObject.AddComponent<SpringJoint2D>();
            fj.connectedBody = player.gameObject.GetComponent<Rigidbody2D>();
            fj.autoConfigureDistance = false;
            fj.frequency = 10f;
            fj.distance = 0;
            StartCoroutine(Free());

        }
        else if (enemy)
        {
            Debug.Log("ddddd");
            var fj = gameObject.AddComponent<SpringJoint2D>();
            fj.connectedBody = enemy.gameObject.GetComponent<Rigidbody2D>();
            fj.autoConfigureDistance = false;
            fj.frequency = 10f;
            fj.distance = 0;
            enemy.TakeDamage(4f);
            StartCoroutine(Free());

        }
        
    }

    IEnumerator Free()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        Destroy(GetComponent<SpringJoint2D>());
        Destroy(gameObject);
    }
}
