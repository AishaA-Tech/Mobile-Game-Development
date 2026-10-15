using UnityEngine;

public class pointCollect : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private int points; //points to be added to player score

    [SerializeField]
    private int score; //stores player's score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        points = 3;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            score += points;
            player.GetComponent<playerStats>().score = score;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = player.GetComponent<playerStats>().score; //fetching player's score
    }
}
