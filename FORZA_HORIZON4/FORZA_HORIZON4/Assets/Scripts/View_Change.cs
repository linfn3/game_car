using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Change : MonoBehaviour
{
    // ָ����һ�˳�������͵����˳������
    public Camera First_Person_View;
    public Camera Third_Person_View;
    public Camera Driver_View;
    public Camera Side_View;

    // Start is called before the first frame update
    void Start()
    {
        First_Person_View.enabled = false;
        Driver_View.enabled = false;
        Third_Person_View.enabled = true;
        Side_View.enabled = false;
    }


    // ����һ����־����������ָʾ��ǰ�Ƿ�Ϊ��һ�˳��ӽ�

    void Update()
    {
        // ���������1�������л�Ϊ��һ�˳�
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchView1();
        }
        // ���������2�������л�Ϊdriver
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchView2();
        }
        // ���������3�������л�Ϊ�����˷Q
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchView3();
        }
        // ���������4�������л�ΪSide
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchView4();
        }

    }

    void SwitchView1()
    {
            First_Person_View.enabled = true;
            Third_Person_View.enabled = false;
            Driver_View.enabled = false;
        Side_View.enabled = false;

    }
    void SwitchView2()
    {
        First_Person_View.enabled = false;
        Third_Person_View.enabled = false;
        Driver_View.enabled =true ;
        Side_View.enabled = false;

    }
    void SwitchView3()
    {
        First_Person_View.enabled = false;
        Third_Person_View.enabled =true ;
        Driver_View.enabled = false;
        Side_View.enabled = false;

    }
    void SwitchView4()
    {
        First_Person_View.enabled = false;
        Third_Person_View.enabled = false;
        Driver_View.enabled = false;
        Side_View.enabled = true;
    }

}
