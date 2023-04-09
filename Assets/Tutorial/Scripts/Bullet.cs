using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    [HideInInspector]
    public Vector3 hitPos { get; private set; }
    private bool hasHit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (!hasHit)
            {
                hitPos = rb.position;
                hasHit = true;
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
        }
    }

    public bool Contact() {
        return hasHit;
    }

    public void resetHit()
    {
        hasHit = false;
        rb.useGravity = true;
    }
}
