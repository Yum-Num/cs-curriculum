using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Singleton : MonoBehaviour
{
    public int coin;
    private int health = 10;
    private int score;
    public static Singleton st;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    private int maxhealth = 10;
    
    void Awake() {
        Debug.Log("hello");
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
        coinText.text = "Coins: " + coin.ToString();
        healthText.text = "Health: " + health.ToString(); 
    }


    public void ChangeHealth(int cht)
    {
        health += cht;
        Debug.Log(health);
        if (health > maxhealth)
        {
            health = maxhealth;
        }

        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = 10;
            coin = 0;
        }
    }
}