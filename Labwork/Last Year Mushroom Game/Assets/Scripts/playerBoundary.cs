using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerBoundary : MonoBehaviour
{
    //boundaries
    [SerializeField]
    private Vector2 player_bound_x;
    [SerializeField]
    private Vector2 player_bound_y;

    //player info
    private Rigidbody2D player_rb;
    [SerializeField]
    private Vector2 player_pos;

    private bool player_dead;//is player dead?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>(); //Getting player's rigidbody2D
        

    }

    void GetPlayerPos() // get player position
    {
        player_pos.x = transform.position.x;
        player_pos.y = transform.position.y;
        player_dead = false; //can't be dead at start
    }
    

    // Update is called once per frame
    void Update()
    {
        GetPlayerPos();
        player_dead = GetComponent<playerStats>().is_dead; //always check for death

        if (!player_dead && player_rb != null)
        {
            //if on x boundary with matching speed in correct direction
            if (transform.position.x < player_bound_x.x && player_rb.linearVelocity.x < 0)
            {
                player_rb.linearVelocity = new Vector2(0f, player_rb.linearVelocity.y);
                player_pos.x = player_bound_x.x;
                transform.position = new Vector3(player_pos.x, player_pos.y, 0f);
                //no movement side to side but can move up
            }
            else if (transform.position.x > player_bound_x.y && player_rb.linearVelocity.x > 0)
            {
                player_rb.linearVelocity = new Vector2(0f, player_rb.linearVelocity.y);
                player_pos.x = player_bound_x.y;
                transform.position = new Vector3(player_pos.x, player_pos.y, 0f);
                //no movement side to side but can move up
            }

            //if on y boundary with matching speed in correct direction
            else if (player_pos.y < player_bound_y.x && player_rb.linearVelocity.y < 0)
            {
                player_rb.linearVelocity = new Vector2(player_rb.linearVelocity.x, 0f);
                player_pos.y = player_bound_y.x;
                //no movement up and down but can side to side
            }
            else if (player_pos.y > player_bound_y.y && player_rb.linearVelocity.y > 0)
            {
                player_rb.linearVelocity = new Vector2(player_rb.linearVelocity.x, 0f);
                player_pos.y = player_bound_y.y;
                //no movement up and down but can side to side
            }
        }

    }
}
