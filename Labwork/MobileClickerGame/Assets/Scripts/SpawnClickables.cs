using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Runtime.CompilerServices;

public class SpawnClickables : MonoBehaviour
{
    // Spawning area coordinates
    private Vector2 SpawnBordersY;
    private Vector2 SpawnBordersX;

    //Accessing the pool for clickables
    [SerializeField] PoolingClickables PoolingObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Assigning borders of spawning area
        SpawnBordersX.x = -1.9f;
        SpawnBordersY.x = 3.3f;
        SpawnBordersX.y = 1.9f;
        SpawnBordersY.y = -3.3f;

        // Starting the spawn waves
        StartCoroutine(SpawningClickables());
    }

    IEnumerator SpawningClickables() // Self explanation
    {
    
        int Clickables = 0; // Amount of things spawned
        int SpawnWaves = 0; // Amount of waves

        while (SpawnWaves < 5)
        {
            while (Clickables < 5)
            {
                // Spawning random object at random coordinate
                float randomPosY = Random.Range(SpawnBordersY.x, SpawnBordersY.y);
                float randomPosX = Random.Range(SpawnBordersX.x, SpawnBordersX.y);
                Vector3 screenPointSpawn = new Vector3(randomPosX, randomPosY, 0);

                // "Spawning" an object from the pooling script at a random location
                PoolingObject.GetClickableTemp(screenPointSpawn);

                Clickables++;
                yield return new WaitForSeconds(1.0f); // Waiting time
            }
            SpawnWaves ++;
            Clickables = 0; // Resetting so another wave of spawns is possible
            yield return new WaitForSeconds(5.0f); // Waiting time

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
