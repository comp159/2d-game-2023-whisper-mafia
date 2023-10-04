using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
