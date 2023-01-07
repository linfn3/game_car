using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exc : MonoBehaviour
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
        Vector3 direction = Camera.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(Camera.position, this.transform.position) < 75 /*&& angle < 30*/)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude < 75)
            {
                //this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isExc", true);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isExc", false);
        }
    }
}