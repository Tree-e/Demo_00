using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test_weapon: MonoBehaviour 
{
    // Use this for initialization
    float nextTime;
    float Bullet_time = 0.3f;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    GameObject bullet = Test_pool.instance.GetObject();
        //    bullet.transform.position = this.transform.position;
        //    //bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 20);
        //}
        while (Time.time >= nextTime)
        {
            GameObject bullet =  Test_pool.instance.GetObject();
            bullet.transform.position = this.transform.position;
            nextTime = Time.time + Bullet_time;
        }
    }
}
