using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class quitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit"); //testing purposes
        Application.Quit(); //close application
    }
}
