using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Change : MonoBehaviour
{
    // 指定第一人称摄像机和第三人称摄像机
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


    // 定义一个标志变量，用于指示当前是否为第一人称视角

    void Update()
    {
        // 如果按下了1键，则切换为第一人称
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchView1();
        }
        // 如果按下了2键，则切换为driver
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchView2();
        }
        // 如果按下了3键，则切换为第三人稱
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchView3();
        }
        // 如果按下了4键，则切换为Side
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
