using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.EnhancedTouch; //Unity Enhanced Touch reccomended
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch; //so it doesn't return errors


public class PlayerTouch : MonoBehaviour
{
    public int Score; // Stores active score
    public int TouchTimes; // Number of times player touches the screen

    //Player Tap Destroy Object
    public GameObject PlayerTapArea;

    protected void OnEnable() //Allows script to use EnhancedTouch.Touch
    {
        EnhancedTouchSupport.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        TouchTimes = 0;
        // Setting variables to 0 when game starts
    }


    void Update()
    {
        // Checking each touch on the screen
        foreach (Touch touch in Touch.activeTouches)
        { 
            if (touch.isTap) // If the detected touch is a tap
            {
                Vector3 CameraPos = Camera.main.ScreenToWorldPoint(touch.screenPosition);
                CameraPos.z = 0; // Ensuring objects appear on screen
                Instantiate(PlayerTapArea, CameraPos, Quaternion.identity); // Summoning the tap area object
                Debug.Log($"Screen pos of touch: {touch.screenPosition}"); // Checking for functionality

                TouchTimes++; // Increasing touch number with each touch
            }
            break;
            
        }

        if (TouchTimes >= 25) // Ending the game when the player has tapped 25 times
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
