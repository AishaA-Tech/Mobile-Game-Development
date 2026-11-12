using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Restarting the game on game complete screen
    public void RestartPress()
    {
        Handheld.Vibrate(); // Vibration when game restarts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
