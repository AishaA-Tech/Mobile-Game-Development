using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouch : MonoBehaviour
{
    //Creating variables referencing input system
    private PlayerInput PlayerInput;
    private InputAction ClickAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        //Getting specific actions from the input action
        PlayerInput = GetComponent<PlayerInput>();
        ClickAction = PlayerInput.actions["Click"]; //Accessible by variable
    }

    //Checking if action has been performed
    private void OnEnable()
    {
        ClickAction.performed += ClickedAction; //+= subscribes to the event
    }
    private void OnDisable()
    {
        ClickAction.performed -= ClickedAction; //-+ unsubscribes from event
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
      
        }
    }
}
