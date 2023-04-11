using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    void EnterPool();
    void ExitPool();

}

public class Test_poolobject : MonoBehaviour, IPoolObject

{
    public void EnterPool()  // 进仓进行存储
    {
        Debug.Log("进入池子的初始化");
    }
    public void ExitPool()     //  出仓
    {
        Debug.Log("退出池子的初始化 -- 获取使用");
    }
    //做碰撞器的物体点一下进行回收
    void OnMouseDown()
    {
        Test_pool.instance.Recycle(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        Test_pool.instance.Recycle(this.gameObject);
    }
}

