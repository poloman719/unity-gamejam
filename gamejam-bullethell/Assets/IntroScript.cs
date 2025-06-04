using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class IntroScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEngine.Video.VideoPlayer vp;

    CanvasRenderer ContinueTextCR;
    double timer = 0;
    bool canContinue = false;

    public VideoClip vc1;
    public VideoClip vc2;
    public VideoClip vc3;
    public VideoClip vc4;
    public VideoClip vc5;
    public List<VideoClip> vcArr;

    int playingVc = 0;

    InputAction continueIntroAction;
    void onContinueIntro(InputAction.CallbackContext context)
    {
        if (canContinue)
        {
            Debug.Log("unpause");
            ContinueTextCR.SetAlpha(0);
            canContinue = false;
            playingVc++;
            vp.clip = vcArr[playingVc];
            vp.frame = -1;
            vp.Play();
        }
    }

    void Start()
    {
        vcArr.Add(vc1);
        vcArr.Add(vc2);
        vcArr.Add(vc3);
        vcArr.Add(vc4);
        vcArr.Add(vc5);

        if (InputSystem.actions)
        {
            continueIntroAction = InputSystem.actions.FindAction("ContinueIntro");
            continueIntroAction.performed += onContinueIntro;
            continueIntroAction.Enable();
        }

        ContinueTextCR = GameObject.FindWithTag("ContinueText").GetComponent<CanvasRenderer>();
        ContinueTextCR.SetAlpha(0);
        vp.frame = -1;
        // vp.url = "Assets/Video/number 2.mp4";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1 / vp.frameRate)
        {
            timer = 0;
        // Debug.Log("frame"+vp.frame);
            Debug.Log("frame"+(double)vp.frame);
            // Debug.Log("frameCount"+vp.frameCount);
            Debug.Log("frameCount"+(double)(vp.frameCount - 2));
            if (!canContinue && ((double)vp.frame >= (double)(vp.frameCount - 2)))
            {
                Debug.Log("Paused");
                vp.Pause();
                canContinue = true;
                ContinueTextCR.SetAlpha(1);
            }
            else if (!canContinue)
            {
                ContinueTextCR.SetAlpha(0);
            }
            // else
            // {
                
            //     vp.frame = -1;
            // }
        }

    }
}
