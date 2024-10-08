using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 targetPos;

    // Start is called before the first frame update

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * Time.deltaTime);
        if (transform.position == targetPos)
        {
            Destroy(gameObject);
        }
    }
}
