using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ClickableSpawner : MonoBehaviour

    // New script attempting new technique of spawning in objects and fixing object overlapping.
{
    [SerializeField] List<GameObject> ClickableList = new List<GameObject>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        // NOT NEEDED MANUALLY ADDING IN EDITOR
        /*foreach (GameObject Clickable in GameObject.FindGameObjectsWithTag("Clickable"))
        {
            ClickableList.Add(Clickable);
        }*/
        
        // Starting the spawn waves
        StartCoroutine(SpawnClickables());
    }

    IEnumerator SpawnClickables() // Self explanation
    {

        int Clickables = 0; // Amount of things spawned
        int SpawnWaves = 0; // Amount of waves

        while (SpawnWaves < 5)
        {
            while (Clickables < 5)
            {
                // Spawning random clickable by enabling
                int ListTotal = ClickableList.Count;
                int RandomSpot = Random.Range(0, ListTotal);
                GameObject SpawnThis = ClickableList[RandomSpot];

                // "Spawning" an object from the pooling script at a random location
                SpawnThis.SetActive(true);

                Clickables++;
                yield return new WaitForSeconds(1.0f); // Waiting time
            }
            SpawnWaves++;
            Clickables = 0; // Resetting so another wave of spawns is possible
            yield return new WaitForSeconds(1.0f); // Waiting time

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
