using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton : MonoBehaviour
{
    int coins;
    private int score;
    public static Singleton St;

    void Awake() {
        if (St != null && St != this)
        {
            Destroy(gameObject);
        }
        else
        {
            St = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}