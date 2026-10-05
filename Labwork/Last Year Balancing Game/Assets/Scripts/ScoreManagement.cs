using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    public int gameScore;
    public TextMeshProUGUI scoreCount;
    public GameObject ClickSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       gameScore = ClickSpawner.GetComponent<ClickSpawner_cs>().gameScore;
        scoreCount.text = "" + gameScore;
    }
}
