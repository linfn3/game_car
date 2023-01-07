using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Control : MonoBehaviour
{
    private float y;
    //���������ٶȲ���
    public float speedOne = 0f;    //����ʵʱ�ٶ�
    private float speedMax = 120f;  //��������ٶ�
    private float speedMin = -20f;  //������С�ٶ�(��������ٶȣ�
    private float speedUpA = 2f;    //�������ټ��ٶȣ�A�����ƣ�
    private float speedDownS = 4f;  //�������ټ��ٶȣ�S�����ƣ�
    private float speedTend = 0.1f; //�޲���ʵʱ�ٶ�����0ʱ���ٶ�
    private float speedBack = 1f;   //�����������ٶ�



    private MeshRenderer[] wheelMesh;
    private WheelCollider[] wheel;
    //private float maxAngle; //���ת���
    private float maxToque; //���ת��
    private float h;
    private float v;
    float a1 = 3;//��Wʱǰ���ļ��ٶ�
    float a2 = -25;//��Ctrl��ɲ�����ٶȣ�ǰ��ʱ��S���ã��þ�ֹ��S�����˳�
    float af = -0.1f;//����awsdʱ�ļ��ٶȣ�Ħ����ɵ�
    float ag = 10;//�Ƕȼ��ٶ�
    float maxAngle = 35;//���ת��
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
        //���Ƴ���ת����ת��
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
        //    //���Ƴ����ٶ�
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        // ��ǰ�ƶ�����
        //        if(speed == 0)
        //        {
        //            speed = 2;
        //        }
        //        //�޸�
        //        if(speed < maxSpeed && speed >=0)
        //        {
        //            speed += a1 * 
        //            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //        }
        //        //�޸�
        //        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //    }

        //    if (Input.GetKey(KeyCode.S))
        //    {
        //        // ����ƶ�����
        //        transform.Translate(Vector3.back * speed * Time.deltaTime);
        //    }

        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        // ����ת������
        //        turnSpeed = 1.5f * speed;
        //        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        //    }



        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        // ����ת������
        //        turnSpeed = 1.5f * speed;
        //        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        //    }



        //    if (Input.GetKey(KeyCode.LeftControl))
        //    {
        //        // ����
        //        speed -= acceleration * Time.deltaTime;
        //    }

        //    speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        // ����
        //        speed += acceleration * Time.deltaTime;
        //    }

        //    speed = Mathf.Clamp(speed, minSpeed, maxSpeed*1.20f);


        //}

        //����W�������ٶ�û�ﵽ������ٶ�����
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //����S�������ٶ�û�ﵽ�㣬���ٶȼ�С
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        //û��ִ���ٶȲ��������ٶȴ�����С�ٶȣ���������
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        //����S�������ٶ�û�дﵽ�����ٶ����ʱ���ҳ������ڿ��Ե���״̬ʱ��������
        if (Input.GetKey(KeyCode.S) && speedOne > speedMin && speedOne <= 0)
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

        //���¿ո�������ֹͣ
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }




        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
        //ʹ��A��D����������������ת
        if (speedOne > 1f || speedOne < -1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }

    }
}


