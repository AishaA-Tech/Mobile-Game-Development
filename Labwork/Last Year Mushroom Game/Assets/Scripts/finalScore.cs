using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class finalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreShow;

    private int final_score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        final_score = scoreMaintain.totalScore;// getting player's final score
        finalScoreShow.text = final_score.ToString();
    }
}
