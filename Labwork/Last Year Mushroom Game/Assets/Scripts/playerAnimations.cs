using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerAnimations : MonoBehaviour
{
    public Animator player_animator; //The player's animation controller

    [SerializeField] //show in inspector
    private float horizontal_move; //Stores the horizontal movement of the player
    [SerializeField]
    private float player_speed;
    [SerializeField]
    private bool is_attacking;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontal_move = 0f; //set as player is not moving
        player = GameObject.Find("Player");
        player_speed = player.GetComponent<playerMovement>().player_speed;
    }

    // Update is called once per frame
    void Update()
    {
        //PLAYER MOVING
        horizontal_move = Input.GetAxisRaw("Horizontal") * player_speed;
        // Getting horizontal movement of player based on movement script
        player_animator.SetFloat("player_speed", Mathf.Abs(horizontal_move));
        // Sets bool in animator to same value, but positive regardless of direction

        //PLAYER ATTACKING
        is_attacking = player.GetComponent<playerAttack>().is_attacking;
        player_animator.SetBool("is_attacking", is_attacking);
    }
}

//Death and damage animations integrated in playerStats script.
//Saves switching between scripts which would take extra lines of code
