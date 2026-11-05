using UnityEngine;

public class TapAreaDestroy : MonoBehaviour
{
    //Public score variable to access
    private GameObject PlayerTouch;
    private int Score;
    public bool Working;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerTouch = GameObject.FindWithTag("PlayerTouch"); // Reference to update score
        Score = PlayerTouch.GetComponent<PlayerTouch>().Score;
        Working = false; // Debugging purposes
    }

    // Tap area colliding with clickables
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Clickable"))
        {
            Working = true; // Inidcating this part of the code is run
            Score++;
            // Destroying both the tap and clickable
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        PlayerTouch.GetComponent<PlayerTouch>().Score = Score; // Updating score

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Working); // Checking for functionality
    }
}
