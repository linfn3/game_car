using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Text;//TMP�ı�
    public Car_Control_opm Car;//�������ƽű�����
    public float vehicleSpeed;//����
    void Start()
    {
        Text = transform.GetComponent<TextMeshProUGUI>();//TMP�ı���ֵ
    }

    // Update is called once per frame
    void Update()
    {
        //����ʵʱ�ٶȸ�ֵ
        vehicleSpeed = Car.speedOne;
        //�ٶ�ת��Ϊkm/h
        float speed = vehicleSpeed * 3.6f * 2.8f/1.2f;
        if (speed < 0) speed = -speed;
        if (speed > 180) speed = 180;
        //�ٶ�ת��Ϊ�ı���ֵ��TMP�ı�����
        Text.text = speed .ToString("0") + "km/h";
    }
}
