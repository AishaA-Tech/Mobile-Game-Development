using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Runtime.CompilerServices;

public class SpawnClickables : MonoBehaviour
{
    private Vector2 SpawnBordersY;
    private Vector2 SpawnBordersX;

    //Creating a list of clickables to spawn
    List<GameObject> SpawnList = new List<GameObject>();
    public GameObject Temp1;
    public GameObject Temp2;
    public GameObject Temp3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adding clickables to spawn list
        SpawnList.Add(Temp1);
        SpawnList.Add(Temp2);
        SpawnList.Add(Temp3);

        //Borders of spawning area
        SpawnBordersX.x = -1.9f;
        SpawnBordersY.x = 3.3f;
        SpawnBordersX.y = 1.9f;
        SpawnBordersY.y = -3.3f;

        //Starting the spawn waves
        StartCoroutine(SpawningClickables());
    }

    IEnumerator SpawningClickables() //Self explanation
    {
    
        int Clickables = 0; //Amount of things spawned
        int SpawnWaves = 0;

        while (SpawnWaves < 5)
        {
            while (Clickables < 5)
            {
                int SpawnListSpot = Random.Range(0, 3);
                var SpawnThis = (SpawnList[SpawnListSpot]);

                float randomPosY = Random.Range(SpawnBordersY.x, SpawnBordersY.y);
                float randomPosX = Random.Range(SpawnBordersX.x, SpawnBordersX.y);
                Vector3 screenPointSpawn = new Vector3(randomPosX, randomPosY, 0);
                Instantiate(SpawnThis, screenPointSpawn, SpawnThis.transform.rotation);
                Clickables++;
                yield return new WaitForSeconds(1.0f);
            }
            SpawnWaves ++;
            Clickables = 0;
            yield return new WaitForSeconds(5.0f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
