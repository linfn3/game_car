using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ĺ���˼�룺�����ʼ�պ��������ı�����ƽ���ȵľ������ǹ̶��ľ���ͨ���ڲ�ʵ�֣����ǹ̶�

public class FollowSide : MonoBehaviour
{
    private Transform targetPos;//�����Ŀ��
    private Vector3 offsetPos;//�̶�λ��

    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3 (4.5f, 1f, 0.07f);
        //offsetPos.x = 1;
        //offsetPos.y = 0;
        //offsetPos.z = 0;
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = targetPos.position + offsetPos;
        transform.rotation = Quaternion.LookRotation(targetPos.position - transform.position);

        //transform.LookAt(targetPos);
    }
}
