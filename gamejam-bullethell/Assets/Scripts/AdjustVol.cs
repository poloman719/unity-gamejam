using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AdjustVol : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
}
