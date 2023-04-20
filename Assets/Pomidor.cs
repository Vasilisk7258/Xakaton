using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomidor : MonoBehaviour
{
    public GameObject pomidor;

    // Update is called once per frame

    public Transform targetBox;
    public float speed = 1f;
    
    void Update()
    {
        
            transform.position += (targetBox.position - transform.position).normalized * speed * Time.deltaTime;
            if ((targetBox.position - transform.position).sqrMagnitude < 0.01f) Destroy(gameObject);

       
    }

    
}
