using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public int blockSpeed = 5;

    public Vector2 SpawnIntervalRange;
    float InstantiationTimer;

    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    float halfBlockWidth;
    float BlockHeight;

    float blockSizeMin = 0.3f;
    float blockSizeMax = 1.8f;

    float blockAngleMin = -15f;
    float blockAngleMax = 15f;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        BlockHeight = blockPrefab.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            InstantiationTimer += Mathf.Lerp(SpawnIntervalRange.y, SpawnIntervalRange.x, Difficulty.GetDifficultyPercent());
            SpawnBlock();
        }
    }

    void SpawnBlock()
    {
        // Randomize starting position
        float minX = -screenHalfWidthInWorldUnits - halfBlockWidth;
        float maxX = screenHalfWidthInWorldUnits + halfBlockWidth;
        float randomX = Random.Range(minX, maxX);
        float y = screenHalfHeightInWorldUnits + BlockHeight;

        // Randomize angle
        float blockAngle = Random.Range(blockAngleMin, blockAngleMax);

        // Spawn block
        GameObject spawnedBlock = (GameObject)Instantiate(blockPrefab, new Vector3(randomX, y, 0), Quaternion.Euler(Vector3.forward * blockAngle));


        // Randomize Size
        float blockSize = Random.Range(blockSizeMin, blockSizeMax);
        spawnedBlock.transform.localScale = Vector2.one * blockSize;
    }
}
