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

    Characteristics keys;
    Characteristics strength;
    Characteristics speed;


    private Sprite[] faces = { };

    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        GameObject keysManager = GameObject.Find("Keys");
        keys = keysManager.GetComponent<Characteristics>(); //находим скрипт который отвечает за ключи
        GameObject strengthManager = GameObject.Find("Strength");
        strength = strengthManager.GetComponent<Characteristics>();
        GameObject speedManager = GameObject.Find("Speed");
        speed = speedManager.GetComponent<Characteristics>();
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
            if (intervalCounter < intervalNumber) // смена анимаций пока кубик крутитс€ и таймер
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
            else // логика, когда кубик докрутилс€
            {
                intervalCounter = 0;
                rolling = false;
                switch(currentFace)
                {
                    case 1: // грань с ключами
                        keys.amount += 1;
                        break;
                    case 2: // грань с увеличением силы
                        strength.amount += 1;
                        break;
                    case 3: // грань с увеличением скорости
                        speed.amount += 1;
                        break;
                }
            }
        }
    }
}
