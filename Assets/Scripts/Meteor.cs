using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject shadowRef;
    [SerializeField] private GameObject stoneRef;
    private GameObject stone;
    private GameObject shadow;
    private SpriteRenderer shadowRenderer;
    [SerializeField] private Color startShadowColor;
    [SerializeField] private Color endShadowColor;
    [SerializeField] private float startShadowScale;
    [SerializeField] private float endShadowScale;
    [SerializeField] private float fallDelay;
    [SerializeField] private float hitRadius;
    [SerializeField] private float fallHeight;
    private Vector3 sScale;
    private Vector3 eScale;
    private Vector3 stoneStartPos;
    private float timePassed;
    
    void Start()
    {
        timePassed = 0;
        stoneStartPos = new Vector3(transform.position.x, transform.position.y + fallHeight, 0f);
        stone = Instantiate(stoneRef, stoneStartPos, Quaternion.identity);
        shadow = Instantiate(shadowRef, transform);
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();
        shadowRenderer.color = startShadowColor;
        sScale = new Vector3(startShadowScale, startShadowScale, startShadowScale);
        eScale = new Vector3(endShadowScale, endShadowScale, endShadowScale);
        shadow.transform.localScale = sScale;
    }
    
    void Update()
    {
        timePassed += Time.deltaTime;
        shadow.transform.localScale = Vector3.Lerp(sScale,eScale, timePassed/fallDelay );
        shadowRenderer.color = Vector4.Lerp(startShadowColor, endShadowColor, timePassed / fallDelay);
        stone.transform.position = Vector3.Lerp(stoneStartPos, transform.position, timePassed / fallDelay);
        if (timePassed >= fallDelay)
        {
            var player = GameObject.Find("Player").GetComponent<Player>();
            Vector2 playerPos = player.transform.position;
            Vector2 meteorPos = transform.position;
            if ((playerPos - meteorPos).magnitude <= hitRadius)
            {
                player.health = 0;
            }
            Destroy(stone);
            Destroy(gameObject);
            
        }
    }
}
