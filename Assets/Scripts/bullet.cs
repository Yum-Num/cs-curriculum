using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dienow());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * Time.deltaTime);
    }

    IEnumerator Dienow()
    {
        yield return new WaitForSeconds(5);
        
        Destroy(gameObject);
    }
}
