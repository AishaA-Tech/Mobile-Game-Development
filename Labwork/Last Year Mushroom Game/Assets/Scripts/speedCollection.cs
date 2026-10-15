using UnityEngine;

public class speedCollection : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float speed_add; //speed increase

    [SerializeField]
    private float player_speed; //stores player's speed

    private float speed_boost_time = 10.0f; // how long boost lasts
    private float timer = 0f;
    private bool is_boost; //whether boost is active

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        speed_add = 1.5f;
        is_boost = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            //speed increase, active boost
            player_speed += speed_add;
            player.GetComponent<playerMovement>().player_speed = player_speed;
            Destroy(other.gameObject);
            is_boost=true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        player_speed = player.GetComponent<playerMovement>().player_speed; //fetching player's speed

        if (is_boost)
        {
            timer += Time.deltaTime;
            if (timer >= speed_boost_time) //if timer over, player no longer boost
            {
                timer = 0f;
                player.GetComponent<playerMovement>().player_speed -= speed_add;
                is_boost = false;
            }
        }
    }
}
