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
    Rigidbody player;

    [Header("Gun Info")]
    public Transform barrel;
    public bool Shot { get; set; }
    public float strength;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = bulletGameObj.transform;
        bulletRb = bulletGameObj.GetComponent<Rigidbody>();
        bulletScript = bulletGameObj.GetComponent<Bullet>();

        player = playerGameObj.GetComponent<Rigidbody>();
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

        if (bulletScript.Contact())
        {
            Swing();
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
        bulletScript.resetHit();
    }

    public void Swing()
    {
        Vector3 PlayerToGrapple = bulletScript.hitPos - player.position;
        player.AddForce(PlayerToGrapple * strength, ForceMode.VelocityChange);
    }
}
