using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    public TopDown_AnimatorController tac;
    public EnemyAI eai;
    public bool touching;

    private void Start()
    {
        tac = GetComponentInChildren<TopDown_AnimatorController>();
        eai = GetComponent<EnemyAI>();
    }
/*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        touching = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy))
        touching = false;
    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (tac.attacking)
            {
                other.gameObject.GetComponent<EnemyAI>().ESetHealth(-1);
            }
        }
    }
}
