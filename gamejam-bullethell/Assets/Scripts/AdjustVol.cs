using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AdjustVol : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start(){
        SetMusicVol();
        SetSFXVol();
    }

    public void SetSFXVol(){
        float vol = sfxSlider.value;
        myMixer.SetFloat("SFXVol", Mathf.Log10(vol)*20);
    }
    public void SetMusicVol(){
        float vol = musicSlider.value;
        myMixer.SetFloat("MusicVol", Mathf.Log10(vol)*20);
    }
}
