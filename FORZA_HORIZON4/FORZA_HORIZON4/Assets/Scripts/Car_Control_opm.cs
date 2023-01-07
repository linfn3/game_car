using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Control_opm : MonoBehaviour
{
    private float y;
    //���������ٶȲ���
    public float speedOne = 0f;    //����ʵʱ�ٶ�
    private float speedMax = 50f/2.8f;  //��������ٶ�
    private float speedMin = -30f;  //������С�ٶ�(��������ٶȣ�
    private float speedUpA = 3f;    //�������ټ��ٶȣ�A�����ƣ�
    private float speedDownS = 4f;  //�������ټ��ٶȣ�S�����ƣ�
    private float speedTend = 0.5f; //�޲���ʵʱ�ٶ�����0ʱ���ٶ�
    private float speedBack = 1f;   //�����������ٶ�

    //������Ч��Χ
    public float minVolume = 0.5f; // ������������С����
    public float maxVolume = 0.85f; // �����������������
    public float minPitch = 0.4f; // ������������С����
    public float maxPitch = 1.2f; // �����������������
    public AudioClip CarSound;
    private bool isIgnited = false;


    private MeshRenderer[] wheelMesh;
    private WheelCollider[] wheel;
    private float h;
    private float v;
    float maxAngle = 35;//���ת��

    public ParticleSystem N2Particles;


    void Start()
    {
        wheelMesh = transform.GetChild(2).GetComponentsInChildren<MeshRenderer>();
        wheel = transform.GetChild(3).GetComponentsInChildren<WheelCollider>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            N2Particles.Play();
            speedMax = 50f / 2.8f * 1.2f;
            speedUpA = 6f;
        }
        else
        {
            N2Particles.Stop();
            speedMax = 50f / 2.8f;
            speedUpA = 3f;
        }

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
        }

        // �ж��Ƿ��Ѿ����
        if (!isIgnited)
        {
            return;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = CarSound;

        // ������������������
        float volume = Mathf.Lerp(minVolume, maxVolume, speedOne / 80.0f);
        // ������������������
        audioSource.volume = volume;
        // ������������������
        float pitch = Mathf.Lerp(minPitch, maxPitch, speedOne / 100.0f);
        // ������������������
        audioSource.pitch = pitch;


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

            speedOne = Mathf.Lerp(speedOne, 0, Time.deltaTime * 2f);
            if (speedOne < 2f) speedOne = 0;
        }


        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);

        //ʹ��A��D����������������ת
        if (speedOne > 1f || speedOne < -1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }

    
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (0 == Mathf.Abs(h) && 0 == Mathf.Abs(v)) return;
        else
        {
            for (int i = 0; i < 2; i++)
            {
                wheel[i].steerAngle = h * maxAngle;
            }
            for (int i = 0; i < 4; i++)
            {
                wheelMesh[i].transform.localRotation = Quaternion.Euler(wheel[i].rpm * 360 / 60, wheel[i].steerAngle, 0);

            }
        }
    }
}


