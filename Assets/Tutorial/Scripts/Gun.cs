using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionProperty pullTriggerAction;
  //  public InputActionProperty grabAction;

    private bool isFiring = false;


    [Header("Bullet Info")]
    public GameObject bulletGameObj;
    public float bulletSpeed;
    Transform bulletTransform;
    Rigidbody bulletRb;
    Bullet bulletScript;

    //  public Transform hand;
    [Header("Player Info")]
    public GameObject playerGameObj;
    Transform playerTransform;
    SpringJoint springJoint;



    [Header("Gun Info")]
    public Transform barrel;
    public bool Shot { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = bulletGameObj.transform;
        bulletRb = bulletGameObj.GetComponent<Rigidbody>();
        bulletScript = bulletGameObj.GetComponent<Bullet>();

        playerTransform = playerGameObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float pullTriggerValue = pullTriggerAction.action.ReadValue<float>();
   //     float grabValue = grabAction.action.ReadValue<float>();

        //if(grabValue > 0.7)
        //{

        //}

        if (pullTriggerValue > 0.7)
        {
            if (!isFiring)
            {
                isFiring = true;
                Fire();
            }
        }
        else
        {
            if (isFiring) 
            {
                isFiring = false;
                CancelFire();
            }
        }

        if (!Shot)
        {
            bulletTransform.position = barrel.position;
            bulletTransform.forward = barrel.forward;
            CancelFire();
        }
    }

    public void Fire()
    {
        Shot = true;
        bulletTransform.position = barrel.position;
        bulletRb.velocity = barrel.forward * bulletSpeed;
    } 

    public void CancelFire()
    {
        Shot = false;
        Destroy(springJoint);
        bulletScript.DestroyJoint();
    }

    public void Swing()
    {
        springJoint = playerGameObj.AddComponent<SpringJoint>();
        springJoint.connectedBody = bulletScript.collisionObject.GetComponent<Rigidbody>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;
        springJoint.anchor = Vector3.zero;

        float disJointToPlayer = Vector3.Distance(playerTransform.position, bulletTransform.position);

        springJoint.maxDistance = disJointToPlayer * 0.9f;
        springJoint.minDistance = disJointToPlayer * 0.1f;
        springJoint.damper = 100f;
        springJoint.spring = 300f;

    }
}
