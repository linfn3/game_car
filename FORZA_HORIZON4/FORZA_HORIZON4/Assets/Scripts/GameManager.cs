using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ���� UI �����ռ�

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject needle;//ָ�����
    public Car_Control_opm Car;//�������ƽű�����
    public float vehicleSpeed;//����
    private float startPosition = 217.6f, endPosition = -39.2f;//�Ǳ���0ֵ�����ֵ��Ӧ��ָ��Ƕ�zֵ
    private float desiredPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���������ƽű��е�ʵʱ�ٶȸ�ֵ�������ٶȱ���
        vehicleSpeed = Car.speedOne;
        //����ʱ���ٶ�ת��Ϊ��ֵ
        if (vehicleSpeed < 0) vehicleSpeed = -vehicleSpeed;
        updateNeedle();
    }

    public void updateNeedle()
    {
        //ָ��ɱ�����
        desiredPosition = startPosition - endPosition;
        //��ǰ����ת��Ϊkm/h��Ӧ��ָ�����
        float temp = vehicleSpeed * 3.6f * 2.8f / (180f*1.2f);
        //��ָ��ת��ʵʱ�ٶȶ�Ӧ��λ��
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }
}
