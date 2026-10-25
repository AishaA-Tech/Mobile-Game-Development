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
        PlayerTouch = GameObject.FindWithTag("PlayerTouch");
        Score = PlayerTouch.GetComponent<PlayerTouch>().Score;
        Working = false;
    }

    //Tap area colliding with clickables
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Clickable"))
        {
            Working = true;
            Score++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerTouch.GetComponent<PlayerTouch>().Score = Score;
        Debug.Log(Working);
    }
}
