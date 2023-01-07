using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera minicamera;//小地图对应的摄影机
    public Transform player;//赛车对应的位置
    public Transform miniplayerIcon;//赛车对应的箭头的位置

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //将游戏对象上方确定距离的位置赋值给小地图的相机位置
        minicamera.transform.position = new Vector3(player.position.x,
            minicamera.transform.position.y, player.position.z);
        //将箭头指向游戏对象的正向使其随游戏对象移动
        miniplayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }
}
