using NUnit.Framework;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

public class ClickSpawner_cs : MonoBehaviour
{

    List<GameObject> shapeList = new List<GameObject>();
    public GameObject circle;
    public GameObject triangle;
    public GameObject square;
    public int gameScore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameScore = 0;
        shapeList.Add(circle);
        shapeList.Add(triangle);
        shapeList.Add(square);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int shapeList_spot = Random.Range(0,3);
            var spawnThis = (shapeList[shapeList_spot]);
            Vector3 mouse_position = Input.mousePosition;
            Vector3 point = Camera.main.ScreenToWorldPoint(mouse_position);
            point[2] = 0.0f;
            gameScore++;
            Instantiate(spawnThis, point, Quaternion.identity);
        }
    }
}
