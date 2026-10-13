using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collectibleSpawn : MonoBehaviour
{
    public GameObject point_collectible; //point
    public GameObject speed_collectible; //speed boost
    public GameObject jump_collectible; //jump boost

    [SerializeField] //test purposes
    private GameObject spawn_this; //thing to spawn in randomisation

    List<GameObject> spawn_list = new List<GameObject>(); //a list to be used in randomisation

    private Vector2 spawn_border_x;
    private Vector2 spawn_border_y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //assigning spawn borders
        spawn_border_x.x = 15.5f;
        spawn_border_x.y = -15.5f;
        spawn_border_y.x = 9.5f;
        spawn_border_y.y = -6.0f;

        //Creating list for boost randomisation
        spawn_list.Add(speed_collectible);
        spawn_list.Add(jump_collectible);

        StartCoroutine(SpawningCollectibles());
    }

    IEnumerator SpawningCollectibles()
    {
        int point_number = 0; //number of point items on scene
        int item_waves = 0; //times items have spawned

        while (item_waves < 5) // item waves incomplete
        {
            while (item_waves < 3) // point waves 3 incomplete, boosts to spawn with
            {
                while (point_number < 15) //point placing incomplete
                {
                    //spawn point
                    float random_pos_x = Random.Range(spawn_border_x.x, spawn_border_x.y);
                    float random_pos_y = Random.Range(spawn_border_y.x, spawn_border_y.y);
                    Vector3 screenPointSpawn = new Vector3(random_pos_x, random_pos_y, 0);
                    Instantiate(point_collectible, screenPointSpawn, point_collectible.transform.rotation);
                    //count point
                    point_number++;
                    yield return new WaitForSeconds(0.3f); //time between point spawns
                }
                item_waves++;
                BoostSpawn();
                yield return new WaitForSeconds(60.0f); //time between waves

            }
            item_waves++;
            BoostSpawn();
            yield return new WaitForSeconds(60.0f); //time between remaining waves

        }
    }

    void BoostSpawn() //identical lines used twice so method created
    {
        ChooseBoost();
        float random_pos_x = Random.Range(spawn_border_x.x, spawn_border_x.y);
        float random_pos_y = Random.Range(spawn_border_y.x, spawn_border_y.y);
        Vector3 screenPointSpawn = new Vector3(random_pos_x, random_pos_y, 0);
        Instantiate(spawn_this, screenPointSpawn, spawn_this.transform.rotation);
    }



    void ChooseBoost()
    {
        int list_spot = Random.Range(0,2); //choosing random
        spawn_this = (spawn_list[list_spot]);
    }

}
