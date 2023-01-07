using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour
{
    // �Ƿ��Ѿ����
    private bool isIgnited = false;
    // �����Ч
    public AudioClip ignitionSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �ж��Ƿ��� B ��
        if (Input.GetKeyDown(KeyCode.B))
        {
            // ����Ѿ���������
            if (isIgnited)
            {
                return;
            }
            // ���
            isIgnited = true;
            // ���ŵ����Ч
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = ignitionSound;
            audioSource.Play();
        }

        // �ж��Ƿ��Ѿ����
        if (!isIgnited)
        {
            return;
        }
    }
}
