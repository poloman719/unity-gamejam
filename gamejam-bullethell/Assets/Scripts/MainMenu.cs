using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public double pressedTime = 0.5;
    public double transitionTime = 10;
    public Animator animator;
    public Sprite pressedSprite;
    double timer;
    int state = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (state == 1 && timer > pressedTime)
        {
            state = 2;
            timer = 0;
            animator.SetTrigger("Start");
            Debug.Log("moving to state 2");
        }
        if (state == 2 && timer > transitionTime)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void StartGame()
    {
        GetComponent<Image>().sprite = pressedSprite;
        state = 1;
        timer = 0;
        Debug.Log("moving to state 1");
        animator.SetBool("Press", true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Application.");
    }
}
