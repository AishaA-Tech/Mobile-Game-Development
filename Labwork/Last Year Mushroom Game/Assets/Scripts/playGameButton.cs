using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playGameButton : MonoBehaviour
{
    

    public void PlayGame() //start the game
    {
        SceneManager.LoadScene("levelOne"); //load lvl1

    }


}
