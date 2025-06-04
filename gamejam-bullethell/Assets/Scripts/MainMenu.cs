using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync("Intro Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Application.");
    }
}
