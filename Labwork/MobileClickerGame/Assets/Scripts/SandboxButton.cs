using UnityEngine;
using UnityEngine.SceneManagement;

public class SandboxButton : MonoBehaviour
{
    // For univeristy lab, checking the device components as the game runs.
    public void SandboxPress()
    {
        SceneManager.LoadScene("Lab4Sandbox");
    }
}
