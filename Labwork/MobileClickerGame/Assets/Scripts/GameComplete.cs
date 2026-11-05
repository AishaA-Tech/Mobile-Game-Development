using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class GameComplete : MonoBehaviour
{
    public static int Score; // Attempt to prevent losing value of score
    public TextMeshProUGUI FinalScore; // Holds final score text game object
    public GameObject PlayerTouch; // To get in game score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying final score on screen
        Score = PlayerTouch.GetComponent<PlayerTouch>().Score;
        FinalScore.text = "" + Score;
    }
}
