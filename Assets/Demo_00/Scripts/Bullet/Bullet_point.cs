using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_point : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Bullet_pool.instance.GetObject();
            bullet.transform.position = this.transform.position;
        }
    }
}
