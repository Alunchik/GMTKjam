using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRain : MonoBehaviour
{
    [SerializeField] private GameObject meteorRef;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;
    [SerializeField] private float maxDelay;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [HideInInspector] public float size;
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        int amount = Random.Range(minAmount, maxAmount + 1);
        for (int i = 0; i < amount; i++)
        {
            StartCoroutine(MakeMeteor());
        }

        Destroy(gameObject, maxDelay + 5f);
    }

    IEnumerator MakeMeteor()
    {
        yield return new WaitForSeconds(Random.Range(0f, maxDelay));
        
        size = Random.Range(minSize, maxSize);
        float aim = Random.Range(0, 10);
        if (aim < 2)
        {
            Instantiate(meteorRef, player.position, Quaternion.identity, transform);
        }
        else
        {
            Instantiate(meteorRef, new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0f),
                Quaternion.identity, transform);
        }

    }
}
