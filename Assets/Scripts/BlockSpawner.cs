using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public int blockSpeed = 5;

    public Vector2 spawnIntervalRange = new Vector2(0.3f, 0.8f);
    float instantiationTimer;

    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    float blockHeight;

    float blockSizeMin = 0.3f;
    float blockSizeMax = 1.8f;

    float blockAngleMin = -15f;
    float blockAngleMax = 15f;

    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        blockHeight = blockPrefab.transform.localScale.y;
    }

    void Update()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            instantiationTimer += Mathf.Lerp(spawnIntervalRange.y, spawnIntervalRange.x, Difficulty.GetDifficultyPercent());
            SpawnBlock();
        }
    }

    void SpawnBlock()
    {
        // Randomize starting position
        float minX = -screenHalfWidthInWorldUnits;
        float maxX = screenHalfWidthInWorldUnits;
        float randomX = Random.Range(minX, maxX);
        float y = screenHalfHeightInWorldUnits + blockHeight;

        // Randomize angle
        float blockAngle = Random.Range(blockAngleMin, blockAngleMax);

        // Spawn block
        GameObject spawnedBlock = (GameObject)Instantiate(blockPrefab, new Vector3(randomX, y, 0), Quaternion.Euler(Vector3.forward * blockAngle));


        // Randomize Size
        float blockSize = Random.Range(blockSizeMin, blockSizeMax);
        spawnedBlock.transform.localScale = Vector2.one * blockSize;
    }
}
