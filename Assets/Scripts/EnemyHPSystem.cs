using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    public float hp;
    private SpriteRenderer sr;
    [SerializeField] private float colorDelay;
    [SerializeField] private Color damageColor;
    private Color defaultColor;
    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        var color = sr.color;
        defaultColor = new Color(color.r, color.g, color.b, color.a);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        var projectile = other.GetComponent<Projectile>();
        if (projectile)
        {
            hp -= projectile.damage;
            sr.color = damageColor;
            StartCoroutine(ReturnNormalColor());
            if (hp <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator ReturnNormalColor()
    {
        yield return new WaitForSeconds(colorDelay);
        sr.color = defaultColor;
    }
}
