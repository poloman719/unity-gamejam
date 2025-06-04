using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseOverlay;
    public GameObject QuitConfirmOverlay;
    [SerializeField] private AudioMixer lowPassCutoffFreq;

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
            lowPassCutoffFreq.SetFloat("Freq", 22000);
        }
        else
        {
            Time.timeScale = 0;
            gamePaused = true;
            PauseOverlay.SetActive(true);
            lowPassCutoffFreq.SetFloat("Freq", 600);
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
