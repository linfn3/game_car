using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//相机跟随的核心思想：让相机始终和汽车中心保持有平滑度的距离差，而非固定的距离差，通过内插实现，而非固定

public class Follow : MonoBehaviour
{
    private Transform targetPos;//跟随的目标
    private Vector3 offsetPos;//固定位置
    private Vector3 tempPos;//内插出来的位置
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
            tempPos = targetPos.position + targetPos.TransformDirection(offsetPos);//坐标转为车辆朝向方向
            transform.position = Vector3.Lerp(transform.position, tempPos, Time.fixedDeltaTime * 3f);//内插使得摄像机平滑跟随
            transform.LookAt(targetPos);//使得摄像机始终望向车辆
        }
    }
}
