
using System.Collections;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    public float hp;
    private SpriteRenderer[] sr;
    private SpriteRenderer srH;
    [SerializeField] private float colorDelay;
    [SerializeField] private Color damageColor;
    [SerializeField] private Color defaultColor;


    private void Start()
    {
        srH = GetComponent<SpriteRenderer>();
        sr = GetComponentsInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        var projectile = other.GetComponent<Projectile>();
        if (projectile && !projectile.enemy)
        {
           TakeDamage(projectile.damage);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        foreach (var renderer in sr)
        {
            renderer.color = damageColor;
        }
        if (srH) srH.color = damageColor;
        StartCoroutine(ReturnNormalColor());
        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator ReturnNormalColor()
    {
        yield return new WaitForSeconds(colorDelay);
        foreach (var renderer in sr)
        {
            renderer.color = defaultColor;
        }
        if (srH) srH.color = defaultColor;
    }
}
