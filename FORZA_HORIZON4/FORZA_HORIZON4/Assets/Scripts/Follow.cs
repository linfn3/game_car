using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ĺ���˼�룺�����ʼ�պ��������ı�����ƽ���ȵľ������ǹ̶��ľ���ͨ���ڲ�ʵ�֣����ǹ̶�

public class Follow : MonoBehaviour
{
    private Transform targetPos;//�����Ŀ��
    private Vector3 offsetPos;//�̶�λ��
    private Vector3 tempPos;//�ڲ������λ��
    private bool is_follow = false;
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3 (1, 2, -4);
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.B))
        {
            is_follow = true;
        }
        if(is_follow)
        {
            tempPos = targetPos.position + targetPos.TransformDirection(offsetPos);//����תΪ����������
            transform.position = Vector3.Lerp(transform.position, tempPos, Time.fixedDeltaTime * 3f);//�ڲ�ʹ�������ƽ������
            transform.LookAt(targetPos);//ʹ�������ʼ��������
        }
    }
}
