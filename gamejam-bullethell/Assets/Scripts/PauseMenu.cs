using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseOverlay;
    public GameObject QuitConfirmOverlay;
    public GameObject lowPassCutoffFreq;

    InputAction pause;

    bool gamePaused = false;
    bool quitting = false;

    void Start()
    {
        if (InputSystem.actions)
        {
            pause = InputSystem.actions.FindAction("Pause");
            pause.performed += onPause;
            pause.Enable();
        }
    }

    void onPause(InputAction.CallbackContext context)
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (gamePaused)
        {
            if (quitting) return;
            Time.timeScale = 1;
            gamePaused = false;
            PauseOverlay.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            gamePaused = true;
            PauseOverlay.SetActive(true);
        }
    }

    public void ConfirmQuitGame()
    {
        quitting = true;
        QuitConfirmOverlay.SetActive(true);
    }

    public void CancelQuitGame()
    {
        quitting = false;
        QuitConfirmOverlay.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Application.");
    }
}
