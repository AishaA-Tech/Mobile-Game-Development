using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float player_speed = 5.0f;
    public float player_jump = 5.0f;
    float horizontal_movement;

    public bool ladder_check; //Variable that stores result for ladder interaction
    public bool climbing_check; //Variable that stores result for climbing check
    public bool ground_check; //Variable that stores result for ground check

    private float vertical; //Stores player's vertical position
    private int jump_times; //Stores number of jumps player has done
    private Rigidbody2D player_rb;
    private SpriteRenderer player_renderer;

    private bool player_dead;//is player dead?




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>(); //Getting player's rigidbody2D
        player_renderer = GetComponent<SpriteRenderer>(); //Getting the sprite renderer for player
        player_rb.linearVelocityX = 0; //Ensuring player is not moving at start
        jump_times = 0; //Setting to 0 because no jumps
        ladder_check = false;
        climbing_check = false;
        ground_check = false;
        player_dead = false; //can't be dead at start
    }


    void Jump(InputAction.CallbackContext context) // Player jump and climb
    {
        vertical = Input.GetAxis("Vertical");

        if ((context.performed) && !ladder_check && ground_check)
        {
            player_rb.AddForceY(player_jump, ForceMode2D.Impulse);
            jump_times ++; //jump made
        }
        //ladder movement
        else if ((Input.GetKey(KeyCode.UpArrow)) 
            && ladder_check && Mathf.Abs(vertical) > 0f)
        {
            climbing_check = true;
        }
        //Jump at ladders
        else if ((context.performed) && ladder_check && ground_check)
        {
            player_rb.AddForceY(player_jump, ForceMode2D.Impulse);
            jump_times++; //jump made
        }
        
        if (!ground_check && (jump_times < 2))
        {
            if ((context.performed) && !ladder_check)
            {
                {
                    player_rb.AddForceY(player_jump, ForceMode2D.Impulse);
                    jump_times++; //jump made
                }
            }
        }

    }



    //TRIGGERS
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladders")) //When player interacts with ladder
        {
            ladder_check = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Ladders")) //When player is no longer interacting with ladder
        {
            ladder_check = false;
            climbing_check = false;
        }
    }

    //COLLIDERS
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) //When player interacts with ground
        {
            ground_check = true;
            jump_times = 0;//ground restarts jump number
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))//When player is no longer interacting with ground
        {
            ground_check = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player_rb.linearVelocity = new Vector2(horizontal_movement * player_speed, player_rb.linearVelocity.y);

        player_dead = GetComponent<playerStats>().is_dead; //always check for death
    }

    public void Move(InputAction.CallbackContext context) //NEW INPUT SYSTEM
    {
        horizontal_movement = context.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        if (!player_dead && player_rb != null)
        {
            if (climbing_check)
            {
                player_rb.gravityScale = 0f;
                player_rb.linearVelocity = new Vector2(player_rb.linearVelocity.x, vertical * player_speed);
            }
            else
            {
                player_rb.gravityScale = 1f;
            }
        }

        
    }
}

