using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject arrowRef;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.LookAt(Input.mousePosition);
            Instantiate(arrowRef, transform);
        }
    }
}
