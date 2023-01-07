using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Control : MonoBehaviour
{
    private float y;
    //车辆控制速度参数
    public float speedOne = 0f;    //车辆实时速度
    private float speedMax = 120f;  //车辆最大速度
    private float speedMin = -20f;  //车辆最小速度(倒车最大速度）
    private float speedUpA = 2f;    //车辆加速加速度（A键控制）
    private float speedDownS = 4f;  //车辆减速加速度（S键控制）
    private float speedTend = 0.1f; //无操作实时速度趋于0时加速度
    private float speedBack = 1f;   //车辆倒车加速度



    private MeshRenderer[] wheelMesh;
    private WheelCollider[] wheel;
    //private float maxAngle; //最大转向角
    private float maxToque; //最大转矩
    private float h;
    private float v;
    float a1 = 3;//按W时前进的加速度
    float a2 = -25;//按Ctrl的刹车加速度，前进时按S无用，得静止后按S才能退车
    float af = -0.1f;//不按awsd时的加速度，摩擦造成的
    float ag = 10;//角度加速度
    float maxAngle = 35;//最大转角
    float speed = 2;
    float dist = 0;
    float turnSpeed = 1;
    float acceleration = 3;
    float minSpeed = 0, maxSpeed = 90;
    void Start()
    {
        maxAngle = 35;
        maxToque = 200;
        wheelMesh = transform.GetChild(2).GetComponentsInChildren<MeshRenderer>();
        wheel = transform.GetChild(3).GetComponentsInChildren<WheelCollider>();
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (0 == Mathf.Abs(h) && 0 == Mathf.Abs(v)) return;
        Move();
    }

    private void Move()
    {
        //控制车轮转动、转向
        for (int i = 0; i < 2; i++)
        {
            wheel[i].steerAngle = h * maxAngle;
        }
        //foreach (var o in wheel)
        //{
        //    //o.motorTorque = maxToque * v;

        //}
        for (int i = 0; i < 4; i++)
        {
            wheelMesh[i].transform.localRotation = Quaternion.Euler(wheel[i].rpm * 360 / 60, wheel[i].steerAngle, 0);

        }
        //    //控制车辆速度
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        // 向前移动汽车
        //        if(speed == 0)
        //        {
        //            speed = 2;
        //        }
        //        //修改
        //        if(speed < maxSpeed && speed >=0)
        //        {
        //            speed += a1 * 
        //            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //        }
        //        //修改
        //        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //    }

        //    if (Input.GetKey(KeyCode.S))
        //    {
        //        // 向后移动汽车
        //        transform.Translate(Vector3.back * speed * Time.deltaTime);
        //    }

        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        // 向左转向汽车
        //        turnSpeed = 1.5f * speed;
        //        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        //    }



        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        // 向右转向汽车
        //        turnSpeed = 1.5f * speed;
        //        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        //    }



        //    if (Input.GetKey(KeyCode.LeftControl))
        //    {
        //        // 减速
        //        speed -= acceleration * Time.deltaTime;
        //    }

        //    speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        // 加速
        //        speed += acceleration * Time.deltaTime;
        //    }

        //    speed = Mathf.Clamp(speed, minSpeed, maxSpeed*1.20f);


        //}

        //按下W键并且速度没达到最大，则速度增加
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //按下S键并且速度没达到零，则速度减小
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        //没有执行速度操作并且速度大于最小速度，则缓慢操作
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        //按下S键并且速度没有达到倒车速度最大时，且车辆处于可以倒车状态时车辆倒车
        if (Input.GetKey(KeyCode.S) && speedOne > speedMin && speedOne <= 0)
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

        //按下空格，则汽车停止
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }




        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
        //使用A和D来控制物体左右旋转
        if (speedOne > 1f || speedOne < -1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }

    }
}


