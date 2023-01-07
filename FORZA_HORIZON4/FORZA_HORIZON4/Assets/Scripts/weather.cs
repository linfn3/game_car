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

 //   public ParticleSystem clearWeather; // ����Ч��
 //   public ParticleSystem cloudWeather;//����Ч��
    public ParticleSystem rainWeather; // ������Ч��
    public ParticleSystem snowWeather; // ��ѩ��Ч��
    // Update is called once per frame
    void Update()
    {
            // �������ּ��̵ġ�F1������F2������F3������F4������
          if (Input.GetKeyDown(KeyCode.F1))
          {
            // ������¡�F1���������л�������Ч��
            RenderSettings.skybox = mats[0];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F2))
          {
            // ������¡�F2���������л�������Ч��
            Debug.Log("Back key not pressed");
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F3))
          {
            // ������¡�F3���������л���������Ч��
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(true);
            snowWeather.gameObject.SetActive(false);
          }
          else if (Input.GetKeyDown(KeyCode.F4))
          {
            // ������¡�F4���������л�����ѩ��Ч��
            RenderSettings.skybox = mats[1];
            rainWeather.gameObject.SetActive(false);
            snowWeather.gameObject.SetActive(true);
          }

    }


}
