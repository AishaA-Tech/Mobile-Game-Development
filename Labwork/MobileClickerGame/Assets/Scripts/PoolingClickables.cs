using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingClickables : MonoBehaviour
{
    //Object that we are pooling
    [SerializeField] GameObject ClickableTemp;

    //Collection for object to be stored inside
    List<GameObject> PoolClickableTemp = new List<GameObject>();

    //Debugging purposes
    int SpawnedTotal = 0;
    int PooledTotal = 0;

    private GameObject SpawnClickablesFromPool(GameObject PrefabClickable, List<GameObject> Pool, Vector3 Location)
    {
        Debug.LogWarning($"Total items spawned: {SpawnedTotal}\n" + 
            $"Total items pooled: {PooledTotal}");


        for (int i = 0; i < Pool.Count; i++)
        {
            if (Pool[i].activeInHierarchy == false)
            {
                Pool[i].transform.position = Location;
                Pool[i].gameObject.SetActive(true);
                PooledTotal++;
                return Pool[i];
            }
        }

        GameObject Object = Instantiate(PrefabClickable, Location, Quaternion.identity);
        Pool.Add(Object);
        SpawnedTotal++;
        return Object;
    }

    public GameObject GetClickableTemp(Vector3 Location)
    {
        return SpawnClickablesFromPool(ClickableTemp, Pool, Location);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
