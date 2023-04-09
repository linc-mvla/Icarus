using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int objectMask;
    [SerializeField] GameObject bullet;
    public Transform player;
    [SerializeField] float seeDist;
    [SerializeField] float shootCooldown;
    [SerializeField] float spawnDist;
    [SerializeField] float bulletSpeed;

    private float lastShot;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastShot = -shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = player.position - rb.position;
        float dist = toPlayer.magnitude;
        //Too far
        if (seeDist < dist) {
            return;
        }
        //See wall
        RaycastHit hit;
        if (Physics.Raycast(rb.position, toPlayer, out hit, dist, ~LayerMask.GetMask("Bullet", "Player")))
        {
            //Debug.DrawRay(rb.position, toPlayer.normalized * hit.distance, Color.white, 0.1f);
            return;
        }
        else {
            //Debug.DrawRay(rb.position, toPlayer.normalized * hit.distance, Color.red, 0.1f);
        }
        Shoot(toPlayer);
    }
    void Shoot(Vector3 toPlayer) {
        if (Time.realtimeSinceStartup - lastShot < shootCooldown) {
            return;
        }
        GameObject b = Instantiate(bullet, rb.position + toPlayer.normalized*spawnDist, rb.rotation);
        b.GetComponent<Rigidbody>().AddForce(toPlayer.normalized * bulletSpeed, ForceMode.VelocityChange);
        lastShot = Time.realtimeSinceStartup;
    }
}
