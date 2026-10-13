using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class managePlayerHealth : MonoBehaviour
{
    public Image health_bar;

    private GameObject player;


    [SerializeField]
    private int health;

    [SerializeField]
    private float max_health = 100f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        health = player.GetComponent<playerStats>().health;
        float health_now = (float)health;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) //not dead
        {
            health = player.GetComponent<playerStats>().health; //up to date

            //update health bar
            health_bar.fillAmount = health / max_health;
        }
        

    }
}
