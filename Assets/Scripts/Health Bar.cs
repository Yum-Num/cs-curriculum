using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Singleton singleton;
    
    // Start is called before the first frame update
    void Start()
    {
        singleton = FindObjectOfType<Singleton>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            singleton.ChangeHealth(-1);
        }
    }
}