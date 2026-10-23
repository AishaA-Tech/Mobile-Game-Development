using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch; //Unity Enhanced Touch reccomended
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch; //so it doesn't return errors

public class PlayerTouch : MonoBehaviour
{

    //Player Tap Destroy Object
    public GameObject PlayerTapArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void Update()
    {
        foreach (Touch touch in Touch.activeTouches)
        { 
            if (touch.isTap) //If the detected touch is a tap
            {
                Vector3 CameraPos = Camera.main.ScreenToWorldPoint(touch.screenPosition);
                CameraPos.z = 0; //Ensuring objects appear on screen
                Instantiate(PlayerTapArea, CameraPos, Quaternion.identity);
                Debug.Log($"Screen pos of touch: {touch.screenPosition}");
            }
            break;
        }
    }
}
