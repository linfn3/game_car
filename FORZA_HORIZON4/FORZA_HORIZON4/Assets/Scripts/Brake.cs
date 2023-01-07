using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    // 刹车音效
    public AudioClip BrakeSound;
    public ParticleSystem speckleParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        // 判断是否按下 Space 键
        if (Input.GetKey(KeyCode.Space))
        {
            // 播放点火音效
            speckleParticles.Play();
            audioSource.clip = BrakeSound;
            audioSource.Play();
        }
        else { 
            speckleParticles.Stop();
            audioSource.Stop();
        }

    }
}
