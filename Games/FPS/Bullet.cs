using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Skinuti health
        Destroy(this.gameObject);
    }
}
