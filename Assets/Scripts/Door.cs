using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] protected TMP_Text lvltext;
    GameObject playerObj;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (player.keys >= 1)
        {
            player.keys = 0;
            player.lvl += 1;
            lvltext.text = "LVL" + player.lvl;
        }
    }
}
