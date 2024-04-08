using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public int poolSize = 10; // Number of cubes to be pre-instantiated
    private GameObject[] cubePool;
    private int currentCubeIndex = 0;

    void Start()
    {
        // Initialize the cube pool
        cubePool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            cubePool[i] = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            cubePool[i].SetActive(false); // Deactivate cubes initially
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCubeFromPool();
        }
    }

    void SpawnCubeFromPool()
    {
        // Activate and reposition the cube from the pool
        cubePool[currentCubeIndex].SetActive(true);
        cubePool[currentCubeIndex].transform.position = transform.position;

        // Move to the next index in the pool
        currentCubeIndex++;
        if (currentCubeIndex >= poolSize)
        {
            currentCubeIndex = 0; // Wrap around to the beginning if reached the end
        }
    }
}