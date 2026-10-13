using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class restartGameButton : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("startScreen"); //load startScreen
    }
}
