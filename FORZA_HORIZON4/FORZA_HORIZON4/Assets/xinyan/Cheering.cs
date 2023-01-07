using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheering : MonoBehaviour
{
    public Transform Camera;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.position - this.transform.position;//方向向量
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(Camera.position, this.transform.position) < 75/* && angle < 30*/)//当相机与人物距离小于75，角度小于30时执行
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);//人物缓慢转向

            anim.SetBool("isIdle", false);
            if (direction.magnitude < 75)//当相机与人物距离小于50时，执行相应动作
            {
                //this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isCheering", true);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isCheering", false);
        }
    }
}