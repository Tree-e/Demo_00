using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test_test : MonoBehaviour
{
    //float nextTime;
    //float Bullet_time = 0.3f;
    // Update is called once per frame
    void Update()
    {
        //if (Time.time >= nextTime)
        //{
        //    Test_pool.instance.GetObject();
        //    nextTime = Time.time + Bullet_time;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            Test_pool.instance.GetObject();
        }
    }
}
