using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouch : MonoBehaviour
{
    //Creating variables referencing input system
    private PlayerInput PlayerInput;
    private InputAction ClickAction;
    private InputAction TouchPosition;

    //Player Tap Destroy Object
    public GameObject PlayerTapArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        //Getting specific actions from the input action
        PlayerInput = GetComponent<PlayerInput>();
        ClickAction = PlayerInput.actions["Click"]; //Accessible by variable
        TouchPosition = PlayerInput.actions["TouchPosition"];
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

    //Checking the information of the action, reading its value
    private void ClickedAction(InputAction.CallbackContext context)
    {
        bool StateValue = context.ReadValueAsButton(); //Gives info as boolean
        Debug.Log(StateValue);

        //Using screen touch position to attack objects
        Vector3 FoundPosition = Camera.main.ScreenToWorldPoint(TouchPosition.ReadValue<Vector2>());
        Instantiate(PlayerTapArea, FoundPosition, PlayerTapArea.transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
