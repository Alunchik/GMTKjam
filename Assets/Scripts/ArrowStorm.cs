using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStorm : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject arrowRef;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;
    [SerializeField] private float maxDelay;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        int amount = Random.Range(minAmount, maxAmount + 1);
        for (int i = 0; i < amount; i++)
        {
            StartCoroutine(MakeArrow());
        }
        Destroy(gameObject,maxDelay+1f);
    }
    

    IEnumerator MakeArrow()
    {
        yield return new WaitForSeconds(Random.Range(0f, maxDelay));
        int type = Mathf.RoundToInt(Random.Range(0f, 12f));
        switch (type)
        {
            case 0:
                Instantiate(arrowRef, new Vector2(11f,Random.Range(-6f,6f)), Quaternion.Euler(0f,0f,90f));
                break;
            case 1:
                Instantiate(arrowRef, new Vector2(-11f,Random.Range(-6f,6f)), Quaternion.Euler(0f,0f,-90f));
                break;
            case 2:
                Instantiate(arrowRef, new Vector2(Random.Range(-11f,11f),6f), Quaternion.Euler(0f,0f,180f));
                break;
            case 3:
                Instantiate(arrowRef, new Vector2(Random.Range(-11f,11f),-6f), Quaternion.identity);
                break;
            case 5:
                Vector3 spawnPos = new Vector2(11f, Random.Range(-6f, 6f));
                Vector3 toPlayer = player.position - spawnPos;
                Instantiate(arrowRef, spawnPos,
                    Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.up, toPlayer, Vector3.forward)));
                break;
            case 6:
                spawnPos = new Vector2(-11f, Random.Range(-6f, 6f));
                toPlayer = player.position - spawnPos;
                Instantiate(arrowRef, spawnPos,
                    Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.up, toPlayer, Vector3.forward)));
                break;
            case 7:
                spawnPos = new Vector2(Random.Range(-11f,11f),6f);
                toPlayer = player.position - spawnPos;
                Instantiate(arrowRef, spawnPos,
                    Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.up, toPlayer, Vector3.forward)));
                break;
            case 8:
                spawnPos = new Vector2(Random.Range(-11f,11f),-6f);
                toPlayer = player.position - spawnPos;
                Instantiate(arrowRef, spawnPos,
                    Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.up, toPlayer, Vector3.forward)));
                break;
            case 9:
                Instantiate(arrowRef, new Vector2(11f,Random.Range(-6f,6f)), Quaternion.Euler(0f,0f,90f));
                break;
            case 10:
                Instantiate(arrowRef, new Vector2(-11f,Random.Range(-6f,6f)), Quaternion.Euler(0f,0f,-90f));
                break;
            case 11:
                Instantiate(arrowRef, new Vector2(Random.Range(-11f,11f),6f), Quaternion.Euler(0f,0f,180f));
                break;
            case 12:
                Instantiate(arrowRef, new Vector2(Random.Range(-11f,11f),-6f), Quaternion.identity);
                break;
        }
    }
}
