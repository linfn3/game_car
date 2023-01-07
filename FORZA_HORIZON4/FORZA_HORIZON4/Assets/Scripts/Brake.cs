using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    // ɲ����Ч
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

        // �ж��Ƿ��� Space ��
        if (Input.GetKey(KeyCode.Space))
        {
            // ���ŵ����Ч
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
