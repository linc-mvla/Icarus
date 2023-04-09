using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Gun gun;

    [HideInInspector]
    public Vector3 hitPos { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (!Contact())
            {
                hitPos = GetComponent<Rigidbody>().position;
            }
        }
    }

    public bool Contact() {
        return hitPos != null;
    }

    public void resetHit()
    {
        hitPos = Vector3.zero;
    }
}
