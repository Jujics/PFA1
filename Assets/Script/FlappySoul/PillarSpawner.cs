using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    public GameObject pillarPrefab;  // The pillar prefab to be spawned
    public float spawnRate = 2f;     // Time between spawns
    public float minHeight = -1f;    // Minimum height for the gap
    public float maxHeight = 3.5f;   // Maximum height for the gap
    public float pillarMoveSpeed = 2f; // Speed at which pillars move

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPillar), 1f, spawnRate);
    }

    void SpawnPillar()
    {
        float spawnYPosition = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnYPosition, 0);

        GameObject pillar = Instantiate(pillarPrefab, spawnPosition, Quaternion.identity);
        pillar.GetComponent<Pillar>().SetMoveSpeed(pillarMoveSpeed);
    }
}