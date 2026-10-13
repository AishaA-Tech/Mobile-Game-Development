using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerAttack : MonoBehaviour
{
    private GameObject AttackArea = default;
    [SerializeField]
    public bool is_attacking = false; //Stores if player is attacking
    private float attack_time = 1.0f; //Player's time to attack
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackArea = transform.GetChild(0).gameObject; //child of player object
        AttackArea.SetActive(false);
    }

    void Attack()
    {
        //the player is attacking
        is_attacking = true;
        AttackArea.SetActive(is_attacking);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) //Player attacks with X
        {
            Attack();
        }

        if (is_attacking) //if the player is attacking, a timer goes off
        {
            timer += Time.deltaTime;
            if (timer >= attack_time) //if timer over, player no longer attacking
            {
                timer = 0f;
                is_attacking = false;
                AttackArea.SetActive(is_attacking);
            }

        }
    }
}
