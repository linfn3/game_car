using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour
{
    // 是否已经点火
    private bool isIgnited = false;
    // 点火音效
    public AudioClip ignitionSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 判断是否按下 B 键
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 如果已经点火，则忽略
            if (isIgnited)
            {
                return;
            }
            // 点火
            isIgnited = true;
            // 播放点火音效
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = ignitionSound;
            audioSource.Play();
        }

        // 判断是否已经点火
        if (!isIgnited)
        {
            return;
        }
    }
}
