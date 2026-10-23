using UnityEngine;

public class TapAreaDestroy : MonoBehaviour
{
    //Public score variable to access

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Tap area colliding with clickables
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Clickable"))
        {
            Destroy(other.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
