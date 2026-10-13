using UnityEngine;

public class enemyAreaAttack : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private GameObject player;
    private int player_health;

    [SerializeField]
    private enemyData data;

    private bool is_damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        damage = data.damage;
        is_damage = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //check if collider is player
        {
            player_health -= damage; //damage player
            player.GetComponent<playerStats>().health = player_health;
            is_damage = true;
            player.GetComponent<playerStats>().is_damage = is_damage;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        player_health = player.GetComponent<playerStats>().health; //up to date player health
    }
    
}
