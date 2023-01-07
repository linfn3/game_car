using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 引用 UI 命名空间

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject needle;//指针变量
    public Car_Control_opm Car;//车辆控制脚本变量
    public float vehicleSpeed;//车速
    private float startPosition = 217.6f, endPosition = -39.2f;//仪表盘0值和最大值对应的指针角度z值
    private float desiredPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //将车辆控制脚本中的实时速度赋值给车辆速度变量
        vehicleSpeed = Car.speedOne;
        //倒车时将速度转换为正值
        if (vehicleSpeed < 0) vehicleSpeed = -vehicleSpeed;
        updateNeedle();
    }

    public void updateNeedle()
    {
        //指针可变区间
        desiredPosition = startPosition - endPosition;
        //当前车速转换为km/h对应的指针比例
        float temp = vehicleSpeed * 3.6f * 2.8f / (180f*1.2f);
        //将指针转到实时速度对应的位置
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }
}
