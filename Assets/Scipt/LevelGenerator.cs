using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] section;
    public Transform playerPos;
    [SerializeField] float renderDist = 200;
    private Vector3 sectionPos;

    private void Start()
    {
        sectionPos = playerPos.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.z + renderDist > sectionPos.z) {
            GenerateSection();
        }
    }

    void GenerateSection() {
        int secNum = Random.Range(0, section.Length);
        Instantiate(section[secNum], sectionPos, Quaternion.identity);
        sectionPos += new Vector3(0, 0, 50);
    }
}
