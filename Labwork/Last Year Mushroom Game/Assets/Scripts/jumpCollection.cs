using UnityEngine;

public class jumpCollection : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float jump_add; //jump force increase

    [SerializeField]
    private float player_jump; //stores player's jump force

    private float jump_boost_time = 10.0f; // how long boost lasts
    private float timer = 0f;
    private bool is_boost; //whether boost is active

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        jump_add = 1.5f;
        is_boost = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpBoost"))
        {
            //jump force increase, active boost
            player_jump += jump_add;
            player.GetComponent<playerMovement>().player_jump = player_jump;
            Destroy(other.gameObject);
            is_boost = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        player_jump = player.GetComponent<playerMovement>().player_jump; //fetching player's jump force

        if (is_boost)
        {
            timer += Time.deltaTime;
            if (timer >= jump_boost_time) //if timer over, player no longer boost
            {
                timer = 0f;
                player.GetComponent<playerMovement>().player_jump -= jump_add;
                is_boost = false;
            }
        }
    }
}
