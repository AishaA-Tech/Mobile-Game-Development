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
            $"Total items pooled: {PooledTotal}"); // Debugging

        //Looking through the collection for an empty space (inactive object)
        for (int i = 0; i < Pool.Count; i++)
        {
            if (Pool[i].activeInHierarchy == false)
            // If an empty space is found this space is returned (object is set to active and used)
            {
                Pool[i].transform.position = Location;
                Pool[i].gameObject.SetActive(true);
                PooledTotal++;
                return Pool[i];
            }
        }
        /* If the empty space (inactive object) is not found, 
           another clickable is created and added to the collection */
        GameObject Object = Instantiate(PrefabClickable, Location, Quaternion.identity);
        Pool.Add(Object);
        SpawnedTotal++;
        return Object; //
    }

    // Other scripts can access and utilise the pool/collection
    public GameObject GetClickableTemp(Vector3 Location)
    {
        return SpawnClickablesFromPool(ClickableTemp, PoolClickableTemp, Location);
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
