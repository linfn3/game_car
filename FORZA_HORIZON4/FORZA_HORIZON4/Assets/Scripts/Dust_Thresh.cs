using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust_Thresh : MonoBehaviour
{
    // ָ�������ĸ�����̳�����ϵͳ
    public Rigidbody carRigidbody;
    public ParticleSystem dustParticles;

    // ����һ����ֵ�����ڿ����̳�Ч���Ĳ���
    public float dustThreshold = 45f;
    void Update()
    {
        // ����������ٶȳ�����ֵ���򲥷��̳�Ч��
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
