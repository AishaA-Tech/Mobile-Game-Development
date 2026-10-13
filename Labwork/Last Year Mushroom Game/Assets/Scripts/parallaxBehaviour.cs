using UnityEngine;

public class parallaxBehaviour : MonoBehaviour
{
    private Vector3 camera_pos; // Player camera's start position
    private Vector3 player_pos; // Player's start position
    public float scroll_amount = 0.1f; // Amount of parallax wanted

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera_pos = GameObject.FindGameObjectWithTag("PlayerCamera").transform.position;
        player_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMotion = GameObject.FindGameObjectWithTag("PlayerCamera").transform.position - camera_pos;
        transform.position = player_pos + scroll_amount * cameraMotion;
    }
}
