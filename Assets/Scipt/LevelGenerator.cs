using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform playerPos;
    public GameObject[] sections;
    [SerializeField] float renderDist = 200;
    [SerializeField] Vector2 gridSize;
    private Dictionary<Vector2Int, GameObject> createdSections = new Dictionary<Vector2Int, GameObject>();

    private Vector2Int renderGridNum;

    private void Start()
    {
        renderGridNum.x = (int)(renderDist/gridSize.x);
        renderGridNum.y = (int)(renderDist/gridSize.y);
    }
    // Update is called once per frame
    void Update()
    {
        int playerX = (int)(playerPos.position.x/gridSize.x);
        int playerZ = (int)(playerPos.position.z/gridSize.y);
        for (int x = -renderGridNum.x; x <= renderGridNum.x; x++) {
            for (int z = -renderGridNum.y; z <= renderGridNum.y; z++)
            {
                Vector2Int cell = new Vector2Int(playerX + x, playerZ + z);
                if (!createdSections.ContainsKey(cell))
                {
                    GenerateSection(cell);
                }
            }
        }
        List<Vector2Int> removeSections = new List<Vector2Int>();
        foreach (KeyValuePair<Vector2Int, GameObject> obj in createdSections) {
            if ((Mathf.Abs(playerX - obj.Key.x) > renderGridNum.x) ||
                (Mathf.Abs(playerZ - obj.Key.y) > renderGridNum.y)) {
                removeSections.Add(obj.Key);
                Destroy(obj.Value);
            }
        }
        foreach (Vector2Int obj in removeSections) {
            createdSections.Remove(obj);
        }
    }

    void GenerateSection(Vector2Int cell) {
        int secNum = Random.Range(0, sections.Length);
        Vector3 pos = new Vector3(gridSize.x * cell.x, 0, gridSize.y * cell.y);
        GameObject o = Instantiate(sections[secNum], pos, Quaternion.identity);
        createdSections.Add(cell, o);
    }
}
