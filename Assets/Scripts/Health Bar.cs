using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            singleton.ChangeHealth(-1);
        }

        if (other.gameObject.CompareTag("Turret_Projectile"))
        {
            singleton.ChangeHealth(-1);
        }
    }
}