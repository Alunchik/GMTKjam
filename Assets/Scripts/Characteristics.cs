using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    public int amount = 0;
    SpriteRenderer[] sprites;

    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                sprites[i].enabled = true;
            }
        }
        if(amount<transform.childCount)
        { 
            for(int i=amount; i<transform.childCount; i++)
            {
                sprites[i].enabled = false;
            }
        }
    }
}
