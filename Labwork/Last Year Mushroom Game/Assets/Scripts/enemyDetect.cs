using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class enemyDetect : MonoBehaviour
{
    private bool is_attacking;

    private GameObject this_enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        is_attacking = false;
        this_enemy = this.transform.parent.gameObject;
            //Since this is child of enemy, parent will be current enemy
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //check if player
        {
            is_attacking = true; //Detect in main script
            this_enemy.GetComponent<enemyGeneral>().is_attacking = is_attacking;
        }
    }

    // Update is called once per frame
    void Update()
    {
        is_attacking = this_enemy.GetComponent<enemyGeneral>().is_attacking;
        //need to be updated on any changes
    }
}
