using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weather : MonoBehaviour
{
    public Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = mats[0];
    }

 //   public ParticleSystem clearWeather; // 晴天效果
 //   public ParticleSystem cloudWeather;//阴天效果
    public ParticleSystem rainWeather; // 下雨天效果
    public ParticleSystem snowWeather; // 下雪天效果
    // Update is called once per frame
    void Update()
    {
            // 监听数字键盘的“F1”、“F2”、“F3”、“F4”按键
          if (Input.GetKeyDown(KeyCode.F1))
          {
            // 如果按下“F1”键，则切换到晴天效果
            RenderSettings.skybox = mats[0];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F2))
          {
            // 如果按下“F2”键，则切换到阴天效果
            Debug.Log("Back key not pressed");
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F3))
          {
            // 如果按下“F3”键，则切换到下雨天效果
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(true);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F4))
          {
            // 如果按下“F4”键，则切换到下雪天效果
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(true);
          }

    }


}
