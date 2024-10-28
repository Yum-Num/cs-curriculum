using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    public EnemyAI eai;
    void Start()
    {
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("mosuedown");
            attacking = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (attacking == true)
            {
                eai.enemyhp -= 1;
            }
        }
    }
}
