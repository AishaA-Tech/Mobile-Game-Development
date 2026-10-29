using UnityEngine;
using UnityEngine.SceneManagement;

public class SandboxButton : MonoBehaviour
{

    public void SandboxPress()
    {
        SceneManager.LoadScene("Lab4Sandbox");
    }
}
