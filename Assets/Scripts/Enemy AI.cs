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
    public Vector3 movementVector;
    public Vector3 direction;
    public enum States
    {
        Wander,
        Chase,
        Attack,
        Die
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

        if (state == States.Chase)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < 1f)
            {
                state = States.Attack;
            }
            movementVector = Vector3.MoveTowards(transform.position, player.transform.position, 4f * Time.deltaTime);
            direction = movementVector - transform.position;
            Debug.Log(direction);
        }

        if (state == States.Attack)
        {
            Debug.Log("attacking");
        }
        if (Mathf.Abs(direction.x)>Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animation.Play("WalkRight");
                Debug.Log("right");
            }
            if (direction.x < 0)
            {
                animation.Play("WalkLeft");
                Debug.Log("left");
            }
        }

        if (Mathf.Abs(direction.y)>Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                animation.Play("WalkUp");
                Debug.Log("up");
            }
            else 
            {
                animation.Play("WalkDown");
                Debug.Log("down");
            }
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
