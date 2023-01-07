using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera minicamera;//С��ͼ��Ӧ����Ӱ��
    public Transform player;//������Ӧ��λ��
    public Transform miniplayerIcon;//������Ӧ�ļ�ͷ��λ��

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //����Ϸ�����Ϸ�ȷ�������λ�ø�ֵ��С��ͼ�����λ��
        minicamera.transform.position = new Vector3(player.position.x,
            minicamera.transform.position.y, player.position.z);
        //����ͷָ����Ϸ���������ʹ������Ϸ�����ƶ�
        miniplayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }
}
