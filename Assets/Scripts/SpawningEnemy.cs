using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyRef;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;
    [SerializeField] private float maxDelay;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private Transform player;
    [SerializeField] private float safeZone;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        int amount = Random.Range(minAmount +  Player.lvl, maxAmount + 2 * Player.lvl);
        for (int i = 0; i < amount; i++)
        {
            StartCoroutine(Spawn());
        }

        Destroy(gameObject, maxDelay + 5f);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1f, maxDelay));
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        while ((spawnPos - player.position).magnitude < safeZone)
        {
            spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f);
        }

        Instantiate(enemyRef, new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f),
                Quaternion.identity);

    }
}
