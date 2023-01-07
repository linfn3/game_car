using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Control_opm : MonoBehaviour
{
    private float y;
    //车辆控制速度参数
    public float speedOne = 0f;    //车辆实时速度
    private float speedMax = 50f/2.8f;  //车辆最大速度
    private float speedMin = -30f;  //车辆最小速度(倒车最大速度）
    private float speedUpA = 3f;    //车辆加速加速度（A键控制）
    private float speedDownS = 4f;  //车辆减速加速度（S键控制）
    private float speedTend = 0.5f; //无操作实时速度趋于0时加速度
    private float speedBack = 1f;   //车辆倒车加速度

    //引擎音效范围
    public float minVolume = 0.5f; // 引擎声音的最小音量
    public float maxVolume = 0.85f; // 引擎声音的最大音量
    public float minPitch = 0.4f; // 引擎声音的最小音调
    public float maxPitch = 1.2f; // 引擎声音的最大音调
    public AudioClip CarSound;
    private bool isIgnited = false;


    private MeshRenderer[] wheelMesh;
    private WheelCollider[] wheel;
    private float h;
    private float v;
    float maxAngle = 35;//最大转角

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
        }

        // 判断是否已经点火
        if (!isIgnited)
        {
            return;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = CarSound;

        // 计算引擎声音的音量
        float volume = Mathf.Lerp(minVolume, maxVolume, speedOne / 80.0f);
        // 设置引擎声音的音量
        audioSource.volume = volume;
        // 计算引擎声音的音调
        float pitch = Mathf.Lerp(minPitch, maxPitch, speedOne / 100.0f);
        // 设置引擎声音的音调
        audioSource.pitch = pitch;


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

            speedOne = Mathf.Lerp(speedOne, 0, Time.deltaTime * 2f);
            if (speedOne < 2f) speedOne = 0;
        }


        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);

        //使用A和D来控制物体左右旋转
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


