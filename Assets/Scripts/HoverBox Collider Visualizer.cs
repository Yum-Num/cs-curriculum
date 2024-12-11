using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoxColliderVisualizer : MonoBehaviour
{
    [SerializeField] private float radius;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x + radius, transform.position.y), new Vector2(Mathf.Cos(transform.position.x * Mathf.Deg2Rad), Mathf.Cos(transform.position.x * Mathf.Deg2Rad)) * radius);
        
    }
}
