using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class Enemy_bulletmove : MonoBehaviour
{
    Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 50);
    }

}
