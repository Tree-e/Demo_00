using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    MeshRenderer render;
    public float speed = 0.1f;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //纹理动画
        render.material.mainTextureOffset -= new Vector2(0, Time.deltaTime * speed);
    }
}
