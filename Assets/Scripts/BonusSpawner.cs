using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

    // TODO: refactor this with the BlockSpawner logic

    public GameObject invincibilityBonusPrefab;
    public Vector2 spawnIntervalRange = new Vector2(10f, 15f);
    float instantiationTimer;

    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    float blockHeight;

    void Start()
    {
        instantiationTimer += InstantiationTime();
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        blockHeight = invincibilityBonusPrefab.transform.localScale.y;
    }

    void Update()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            instantiationTimer += InstantiationTime();
            SpawnBonus();
        }
    }

    float InstantiationTime() {
        int spawnDelayPercentage = Random.Range(0, 100);
        return Mathf.Lerp(spawnIntervalRange.y, spawnIntervalRange.x, spawnDelayPercentage);
    }

    void SpawnBonus()
    {
        // Randomize starting position
        float minX = -screenHalfWidthInWorldUnits;
        float maxX = screenHalfWidthInWorldUnits;
        float randomX = Random.Range(minX, maxX);
        float y = screenHalfHeightInWorldUnits + blockHeight;

        Instantiate(invincibilityBonusPrefab, new Vector3(randomX, y, 0), Quaternion.identity);
    }
}
