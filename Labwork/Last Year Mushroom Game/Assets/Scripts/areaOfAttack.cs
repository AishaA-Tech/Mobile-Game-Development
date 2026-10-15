using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class areaOfAttack : MonoBehaviour
{
    private int damage = 2; //damage player does to enemies
    private GameObject enemy = default; //the enemy being fought
    private int enemy_health = 0;
    private bool is_damage;
    private int score;
    private GameObject player;

    void Start()
    {
        is_damage = false;
        player = this.transform.parent.gameObject;
        score = player.GetComponent<playerStats>().score;

        //Since this is child of enemy, parent will be current enemy
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //check if collider is player
        {
            enemy = other.gameObject;
            enemy_health = enemy.GetComponent<enemyGeneral>().health;
            is_damage = true;

            enemy_health -= damage; //damage enemy
            enemy.GetComponent<enemyGeneral>().health = enemy_health;
            enemy.GetComponent<enemyGeneral>().is_damage = is_damage;

            //increase player score
            score += damage;
            player.GetComponent<playerStats>().score = score;

        }
    }

}
