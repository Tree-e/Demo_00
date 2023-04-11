using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    int score;
    Rigidbody rig;
    public float speed = 15f;
    public Vector3 dir = Vector3.forward;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        rig.velocity = dir * speed;
    }

    void Update()
    {
        
    }
}
