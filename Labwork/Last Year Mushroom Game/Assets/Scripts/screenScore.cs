using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class screenScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private GameObject player;



    [SerializeField]
    private int player_score; //player score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player_score = player.GetComponent<playerStats>().score;// getting player's score
            scoreText.text = player_score.ToString();
        }
    }
}
