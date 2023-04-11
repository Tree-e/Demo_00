using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpClock : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
