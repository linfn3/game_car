using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioSource bgmAudio;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = 0.15f;
    }

    private void Update()
    {
        bgmAudio.volume = volumeSlider.value;
    }

}
