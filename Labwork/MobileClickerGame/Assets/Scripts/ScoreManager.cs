using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreDisplay;
    public GameObject PlayerTouch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score = PlayerTouch.GetComponent<PlayerTouch>().Score;
        ScoreDisplay.text = "" + Score;
    }
}
