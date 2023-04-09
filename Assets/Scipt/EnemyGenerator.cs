using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public Transform playerPos;
    public GameObject[] enemies;
    [SerializeField] float[] distSpawn = {100f, 200f}; //[min, max]

    //private List<GameObject>[] createdEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
