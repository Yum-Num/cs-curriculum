using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 3;
    public GameObject bullet;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            
        }
    }

    void Update()
    {
        
        coolDown -= Time.deltaTime;
        if (player && coolDown < 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject instance = Instantiate(bullet, transform.position, quaternion.identity);
        instance.GetComponent<bullet>().targetPos = player.transform.position;
        coolDown = firerate;
    }
}
