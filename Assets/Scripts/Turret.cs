using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 3;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && coolDown < 1)
        {
            GameObject instance = Instantiate(bullet, transform.position, quaternion.identity);
            instance.GetComponent<bullet>().targetPos = other.transform.position;
            firerate -= Time.deltaTime;
            coolDown = firerate;
        }
    }
}
