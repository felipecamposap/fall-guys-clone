using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
  
}
