using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Text;//TMP文本
    public Car_Control_opm Car;//车辆控制脚本对象
    public float vehicleSpeed;//车速
    void Start()
    {
        Text = transform.GetComponent<TextMeshProUGUI>();//TMP文本赋值
    }

    // Update is called once per frame
    void Update()
    {
        //车辆实时速度赋值
        vehicleSpeed = Car.speedOne;
        //速度转换为km/h
        float speed = vehicleSpeed * 3.6f * 2.8f/1.2f;
        if (speed < 0) speed = -speed;
        if (speed > 180) speed = 180;
        //速度转换为文本赋值给TMP文本对象
        Text.text = speed .ToString("0") + "km/h";
    }
}
