using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bulletgo : MonoBehaviour
{
    float nextTime1;
    float Bullet_time = 0.4f;
    Vector3 euler;

    GameObject bullet;

    //int level = 2;

    void Start()
    {
        gete();
    }

    void Update()
    {
        lv1();
    }
    void lv1()
    {
        while (Time.time >= nextTime1)
        {
            //Debug.Log(this.gameObject.name);
            bullet = Enemys_bulletpool.enemys_Bulletpool.Getbullet();
            bullet.transform.position = this.transform.position;
            //bullet.transform.rotation = Quaternion.Euler(euler);
            nextTime1 = Time.time + Bullet_time;
        }
    }
    void gete()
    {
        if (this.transform.position.x > 0)
        {
            euler = new Vector3(90, 30, 0);
        }
        else
        {
            euler = new Vector3(90, -30, 0);
        }
    }
}
