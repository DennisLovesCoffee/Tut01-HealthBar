using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class moveZombie : MonoBehaviour
{
    [SerializeField] 
    private float radius = 2f;

    private Transform t;
    
    private void Start()
    {
        t = transform;
    }

    void Update()
    {
        
        t.position += radius * Time.deltaTime * t.forward;
        t.Rotate(0f, -1f, 0f);
    }
}
