using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2_pool1 : MonoBehaviour
{
    //Unity中实现单例的方法  方便访问池子
    public static Lv2_pool1 lv2_pool1;
    //有多少子弹
    public int lv2_pool1_count;
    //进哪种子弹
    public GameObject lv2_pool1_objprf;
    //存放在哪
    public Queue<GameObject> queue = new Queue<GameObject>();
    void Awake()
    {
        lv2_pool1 = this;
        //objPrefab = Resources.Load<GameObject>("Bullet6");
        lv2_pool1_count = 20;
        Init();
    }
    //存放子弹
    public void Init()
    {
        PoolManager poolManager = lv2_pool1_objprf.GetComponent<PoolManager>();
        if (poolManager != null)
        {
            for (int i = 0; i < lv2_pool1_count; i++)
            {
                //存储子弹到弹夹中
                GameObject obj = GameObject.Instantiate(lv2_pool1_objprf);
                obj.name = "lv2_left";
                //obj.transform.position = new Vector3(10000,10000, 10000);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
        }
        else
        {
            Debug.Log("不是我想要的子弹，初始化失败");
            return;
        }
    }
    //打出子弹  
    public GameObject GetObject()
    {
        GameObject result = null;
        //判断是否有货
        if (queue.Count >= 1)
        {
            result = queue.Dequeue();
            result.SetActive(true);
            result.GetComponent<PoolManager>().OutPool();
        }
        //没货
        else
        {
            result = GameObject.Instantiate(lv2_pool1_objprf);
            result.GetComponent<PoolManager>().OutPool();
        }
        return result;
    }
    //回收子弹
    public void Recycle(GameObject obj)
    {
        PoolManager poolManager = obj.GetComponent<PoolManager>();
        if (poolManager != null)
        {
            //禁止使用
            obj.SetActive(false);
            //初始化
            poolManager.InPool();
            //存入队列
            queue.Enqueue(obj);
        }
    }
}
