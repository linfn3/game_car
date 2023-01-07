using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//相机跟随的核心思想：让相机始终和汽车中心保持有平滑度的距离差，而非固定的距离差，通过内插实现，而非固定

public class FollowSide : MonoBehaviour
{
    private Transform targetPos;//跟随的目标
    private Vector3 offsetPos;//固定位置

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
