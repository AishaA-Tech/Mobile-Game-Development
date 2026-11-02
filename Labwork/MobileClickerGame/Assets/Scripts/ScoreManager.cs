using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score; // Stores game score
    public TextMeshProUGUI ScoreDisplay; // Score text game object
    public GameObject PlayerTouch; // To get in game score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying current score on screen
        Score = PlayerTouch.GetComponent<PlayerTouch>().Score;
        ScoreDisplay.text = "" + Score;
    }
}
