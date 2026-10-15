using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class SpawnClickables : MonoBehaviour
{
    private Vector2 SpawnBordersY;
    private Vector2 SpawnBordersX;
    public GameObject SpawnThis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
