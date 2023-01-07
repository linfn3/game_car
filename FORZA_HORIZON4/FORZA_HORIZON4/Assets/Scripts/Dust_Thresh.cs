using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust_Thresh : MonoBehaviour
{
    // 指定车辆的刚体和烟尘粒子系统
    public Rigidbody carRigidbody;
    public ParticleSystem dustParticles;

    // 定义一个阈值，用于控制烟尘效果的播放
    public float dustThreshold = 45f;
    void Update()
    {
        // 如果车辆的速度超过阈值，则播放烟尘效果
        if (carRigidbody.velocity.magnitude > dustThreshold)
        {
            dustParticles.Play();
        }
        else
        {
            dustParticles.Stop();
        }
    }
}
