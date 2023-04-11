using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliet_bulletgo : MonoBehaviour
{
    float nextTime1;
    float Bullet_time = 0.3f;

    GameObject bullet;
    void Update()
    {
        bgo();
    }
    void bgo()
    {
        while (Time.time >= nextTime1)
        {
            //Debug.Log(this.gameObject.name);
            bullet = Eliet_bulletpool.eliet_Bulletpool.Getbullet();
            bullet.transform.position = this.transform.position;
            //bullet.transform.rotation = Quaternion.Euler(euler);
            nextTime1 = Time.time + Bullet_time;
        }
    }
}
