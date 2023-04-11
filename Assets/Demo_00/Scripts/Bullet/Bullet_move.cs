using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_move : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * Ship_atb.ship_Atb.getspeed());
    }
}
