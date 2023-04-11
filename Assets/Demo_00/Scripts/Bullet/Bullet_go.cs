using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_go : MonoBehaviour
{
    public static Bullet_go bullet_go;
    float nextTime1;
    float nextTime2;
    float Bullet_time = 0.1f;

    GameObject bullet;
    GameObject bullet1;
    GameObject bullet2;

    GameObject bullet3;
    GameObject bullet4;
    GameObject bullet5;
    GameObject bullet6;
    GameObject bullet7;

    bool skillup = false;
    //int level = 2;

    private void Awake()
    {
        bullet_go = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //gobullet();
        //gobullet(Ship_atb.ship_Atb.level);
        gogogo(skillup);
    }
    void lv1()
    {
        while(Time.time >= nextTime1)
        {
            bullet = Bullet_pool.instance.GetObject();
            bullet.name = "LV1";
            bullet.transform.position = this.transform.position;

            bullet3 = Bullet_pool.instance.GetObject();
            bullet3.transform.position = this.transform.position;
            bullet3.transform.rotation = Quaternion.Euler(0, 10, 0);

            nextTime1 = Time.time + Bullet_time;
        }
    }
    void lv2()
    {
        while (Time.time >= nextTime2)
        {
            bullet1 = Lv2_pool1.lv2_pool1.GetObject();
            bullet2 = Lv2_pool2.lv2_pool2.GetObject();

            bullet1.transform.position = this.transform.position;
            bullet2.transform.position = this.transform.position;

            bullet1.transform.rotation = Quaternion.Euler(0, 30, 0);
            bullet2.transform.rotation = Quaternion.Euler(0, -30, 0);

            nextTime2 = Time.time + Bullet_time;
        }
    }
    void gobullet(int lv)
    {
        lv1();
        if (lv > 1)
        {
            lv2();
        }
    }
    //void gobullet()
    //{
    //    while (Time.time >= nextTime1)
    //    {
    //        bullet3 = Bullet_pool.instance.GetObject();
    //        bullet.name = "LV1";
    //        bullet.transform.position = this.transform.position;
    //
    //        bullet4 = Bullet_pool.instance.GetObject();
    //        bullet.name = "LV1";
    //        bullet.transform.position = this.transform.position;
    //        bullet.transform.rotation = Quaternion.Euler(0, 10, 0);
    //
    //        bullet5 = Bullet_pool.instance.GetObject();
    //        bullet.name = "LV1";
    //        bullet.transform.position = this.transform.position;
    //        bullet.transform.rotation = Quaternion.Euler(0, -10, 0);
    //
    //        bullet6 = Bullet_pool.instance.GetObject();
    //        bullet.name = "LV1";
    //        bullet.transform.position = this.transform.position;
    //        bullet.transform.rotation = Quaternion.Euler(0, 20, 0);
    //
    //        bullet7 = Bullet_pool.instance.GetObject();
    //        bullet.name = "LV1";
    //        bullet.transform.position = this.transform.position;
    //        bullet.transform.rotation = Quaternion.Euler(0, -20, 0);
    //
    //        nextTime1 = Time.time + Bullet_time;
    //    }
    //}

    void gogogo(bool up)
    {
        while (Time.time >= nextTime1)
        {
            bullet3 = Bullet_pool.instance.GetObject();
            bullet3.name = "LV1";
            bullet3.transform.position = this.transform.position;
            bullet3.transform.rotation = Quaternion.Euler(0, 0, 0);
            
            bullet4 = Bullet_pool.instance.GetObject();
            bullet4.name = "LV1";
            bullet4.transform.position = this.transform.position;
            bullet4.transform.rotation = Quaternion.Euler(0, 5, 0);

            bullet5 = Bullet_pool.instance.GetObject();
            bullet5.name = "LV1";
            bullet5.transform.position = this.transform.position;
            bullet5.transform.rotation = Quaternion.Euler(0, -5, 0);

            if (up)
            {
                bullet6 = Bullet_pool.instance.GetObject();
                bullet6.name = "LV1";
                bullet6.transform.position = this.transform.position;
                bullet6.transform.rotation = Quaternion.Euler(0, 10, 0);

                bullet7 = Bullet_pool.instance.GetObject();
                bullet7.name = "LV1";
                bullet7.transform.position = this.transform.position;
                bullet7.transform.rotation = Quaternion.Euler(0, -10, 0);
            }

            nextTime1 = Time.time + Bullet_time;
        }
    }
    public void setskillup(bool set)
    {
        skillup = set;
    }
}
