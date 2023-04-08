using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] section;
    public Transform playerPos;
    [SerializeField] float renderDist = 200;
    private List<GameObject> createdSections = new List<GameObject>();
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
            List<GameObject> removeSections = new List<GameObject>();
            foreach (GameObject obj in createdSections) {
                if (Vector3.Distance(obj.transform.position, playerPos.position) > renderDist) {
                    removeSections.Add(obj);
                }
            }
            foreach (GameObject obj in removeSections) {
                createdSections.Remove(obj);
                Destroy(obj);
            }
        }
    }

    void GenerateSection() {
        int secNum = Random.Range(0, section.Length);
        GameObject o = Instantiate(section[secNum], sectionPos, Quaternion.identity);
        createdSections.Add(o);
        sectionPos += new Vector3(0, 0, 50);
    }
}
