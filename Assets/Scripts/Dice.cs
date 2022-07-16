using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private GameObject arrowStorm;
    
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
    Player player;


    private Sprite[] faces = { };

    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        GameObject keysManager = GameObject.Find("Keys");
        keys = keysManager.GetComponent<Characteristics>(); //������� ������ ������� �������� �� �����
        GameObject strengthManager = GameObject.Find("Strength");
        strength = strengthManager.GetComponent<Characteristics>();
        GameObject speedManager = GameObject.Find("Speed");
        speed = speedManager.GetComponent<Characteristics>();
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
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
            if (intervalCounter < intervalNumber) // ����� �������� ���� ����� �������� � ������
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
            else // ������, ����� ����� ����������
            {
                intervalCounter = 0;
                rolling = false;
                switch(currentFace)
                {
                    case 1: // ����� � �������
                        keys.amount += 1;
                        player.keys += 1;
                        break;
                    case 2: // ����� � ����������� ����
                        strength.amount += 1;
                        player.damage += 1;
                        break;
                    case 3: // ����� � ����������� ��������
                        speed.amount += 1;
                        player.speed += 1.5f;
                        break;
                    case 4: // ����� � ����������� ��������
                        if (player.speed >= 6.5f)
                        {
                            player.speed -= 1.5f;
                            speed.amount -= 1;
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        Instantiate(arrowStorm, Vector3.zero, Quaternion.identity);
                        break;
                    case 7:
                        break;
                }
            }
        }
    }
}
