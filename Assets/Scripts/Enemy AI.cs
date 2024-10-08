using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public List<GameObject> points;
    public int pointer = 0;
    public GameObject player;
    public States state;
    public enum States
    {
        Wander,
        Chase
    }
    void Update()
    {
        if (state == States.Wander)
        {
            if (Vector3.Distance(transform.position, points[pointer].transform.position) < 0.01f)
            {
                pointer++;
                pointer %= points.Count;
            }
            transform.position = Vector3.MoveTowards(transform.position, points[pointer].transform.position, 1 * Time.deltaTime);    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
}
