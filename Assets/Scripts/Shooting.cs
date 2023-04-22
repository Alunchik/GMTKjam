using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject arrowRef;
    public bool tripple;
    public float trippleSpread;
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.rotation = Quaternion.Euler(0f,0f, Vector3.SignedAngle(Vector3.up, mousePos, Vector3.forward));
        if (Input.GetMouseButtonDown(0))
        {
            if (tripple)
            {
                transform.Rotate(Vector3.forward, trippleSpread);
                Instantiate(arrowRef, transform.position, transform.rotation);
                transform.Rotate(Vector3.forward, -2 * trippleSpread);
                Instantiate(arrowRef, transform.position, transform.rotation);
                transform.Rotate(Vector3.forward, trippleSpread);
            }

            Instantiate(arrowRef, transform.position, transform.rotation);
        }
    }
}
