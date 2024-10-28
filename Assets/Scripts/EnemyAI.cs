using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public Singleton st;
    private float cooldown = 4f;
    public int enemyhp = 10;
    private GameObject enemy;
    public GameObject Axel;
    public enum States
    {
        Wander,
        Chase,
        Attack,
        Die
    }

    public void Start()
    {
        st = FindFirstObjectByType<Singleton>();
    }

    void Update()
    {
        Debug.Log(enemyhp);
        cooldown -= Time.deltaTime;
        if (state == States.Wander)
        {
            movementVector =
                Vector3.MoveTowards(transform.position, points[pointer].transform.position, 2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[pointer].transform.position) < 0.01f)
            {
                pointer++;
                pointer %= points.Count;
            }

            direction = movementVector - transform.position;
            transform.position = movementVector;
        }

        if (state == States.Chase)
        {
            movementVector = Vector3.MoveTowards(transform.position, player.transform.position, 2.5f * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
            {
                state = States.Attack;
            }

            direction = movementVector - transform.position;
            transform.position = movementVector;
        }

        if (state == States.Attack)
        {
            if (Vector3.Distance(player.transform.position, transform.position)>1.5f)
            {
                state = States.Chase;
            }
            
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    if (cooldown <= 1)
                    {
                        animation.Play("AttackRight");
                        st.ChangeHealth(-2);
                        cooldown = 4;
                    }
                }

                if (direction.x < 0)
                {
                    if (cooldown <= 1)
                    {
                        animation.Play("AttackLeft");
                        st.ChangeHealth(-2);
                        cooldown = 4;
                    }
                }
            }

            if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (direction.y > 0)
                {
                    if (cooldown <= 1)
                    {
                        animation.Play("AttackUp");
                        st.ChangeHealth(-2);
                        cooldown = 4;
                    }
                }
                else if (direction.y < 0)
                {
                    if (cooldown <= 1)
                    {
                        animation.Play("AttackDown");
                        st.ChangeHealth(-2);
                        cooldown = 4;
                    }
                }
                
            }
            if (Vector3.Distance(transform.position, player.transform.position) > 1.5f)
            {
                state = States.Chase;
            }
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animation.SetInteger("Direction", 1);
                Debug.Log("right");
            }

            if (direction.x < 0)
            {
                animation.SetInteger("Direction", 3);
                Debug.Log("left");
            }
        }

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                animation.SetInteger("Direction", 0);
                Debug.Log("up");
            }
            else
            {
                animation.SetInteger("Direction", 2);
                Debug.Log("down");
            }
        }
        if (enemyhp < 1)
        {
            Destroy(enemy);
            Instantiate(Axel, transform.position, quaternion.identity);
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
}