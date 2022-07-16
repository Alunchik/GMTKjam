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
        if (amount > 0 && amount <= sprites.Length)
        {
            for (int i = 0; i < amount; i++)
            {
                sprites[i].enabled = true;
            }
        }
        if(amount< sprites.Length)
        { 
            for(int i=amount; i< sprites.Length; i++)
            {
                sprites[i].enabled = false;
            }
        }
    }
}
