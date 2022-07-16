using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private float intervalTime = 0.3f;
    [SerializeField] private int intervalNumber = 5;
    public static bool rolling = false;

    private float timer = 0;

    private SpriteRenderer sr;
    private Sprite faceSprite;
    private int intervalCounter = 0;
    private int currentFace = 0;
    private System.Random rand = new System.Random();


    private Sprite[] faces = { };

    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if ((Input.GetKey("r")))
        {
            rolling = true; 
        }
    }

    void FixedUpdate()
    {
        if (rolling == true)
        {
            if (intervalCounter < intervalNumber) // смена анимаций пока кубик крутится и таймер
            {
                if (timer > intervalTime)
                {
                    timer = 0;
                    int old = currentFace;
                    while(currentFace==old)
                    {
                        currentFace = rand.Next(1, 7); 
                    }
                    SpriteRenderer srNew = transform.GetChild(currentFace).GetComponent<SpriteRenderer>();
                    sr.enabled = false;
                    srNew.enabled = true;
                    sr = srNew;
                    intervalCounter += 1;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
            else // логика, когда кубик докрутился
            {
                intervalCounter = 0;
                rolling = false;
            }
        }
    }
}
