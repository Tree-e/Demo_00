using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Eliet_bulletmove : MonoBehaviour
{
    Rigidbody rig;
    void Awak()
    {
        rig = transform.GetComponent<Rigidbody>();
        rig.useGravity = false;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 70);
    }
}
