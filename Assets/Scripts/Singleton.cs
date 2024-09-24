using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Singleton : MonoBehaviour
{
    public int coin;
    private int health = 10;
    private int score;
    public static Singleton st;
    public TextMeshProUGUI coinText;
    void Awake() {
        if (st != null && st != this)
        {
            Destroy(gameObject);
        }
        else
        {
            st = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        coinText.text = coin.ToString();
    }

    public void ChangeHealth(int cht)
    {
        health += cht;
        Debug.Log(health.ToString());
    }
}