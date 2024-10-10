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
    public States state = States.Wander;
    public Animator animation;
    public enum States
    {
        Wander,
        Chase,
        Attack
    }
    void Update()
    {
        Vector3 movementVector = default;
        if (state == States.Wander)
        {
            if (Vector3.Distance(transform.position, points[pointer].transform.position) < 0.01f)
            {
                pointer++;
                pointer %= points.Count;
            }
            
            movementVector = Vector3.MoveTowards(transform.position, points[pointer].transform.position, 1 * Time.deltaTime);
            transform.position = movementVector;
        }

        if (state == States.Chase)
        {
            movementVector = Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
            transform.position = movementVector;
            if (Vector3.Distance(transform.position, player.transform.position) < 1f)
            {
                state = States.Attack;
            }
        }

        if (state == States.Attack)
        {
            Debug.Log("attacking");
        }

        movementVector = movementVector.normalized;
        if (Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y))
        {
            if (Mathf.Sign())
            {
                animation.Play();
            }
            
        } 
        else if (Mathf.Abs(movementVector.y) > Mathf.Abs(movementVector.x))
        {
            //do y stuff
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            state = States.Chase;
        }
    }

    private void onTriggerExit2d(Collider2D other)
    {
        state = States.Wander;
    }
}
