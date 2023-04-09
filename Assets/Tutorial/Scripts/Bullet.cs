using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Gun gun;
    FixedJoint fixedJoint;

    [HideInInspector]
    public GameObject collisionObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collisionObject = collision.gameObject;
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }

        gun.Swing();
    }

    public void DestroyJoint()
    {
        Destroy(fixedJoint);
    }
}
