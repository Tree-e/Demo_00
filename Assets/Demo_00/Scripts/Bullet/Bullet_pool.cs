using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_pool : MonoBehaviour
{
    //Unity中实现单例的方法  方便访问池子
    public static Bullet_pool instance;
    //有多少子弹
    public int initCount;
    //进哪种子弹
    public GameObject objPrefab;
    //存放在哪
    public Queue<GameObject> queue = new Queue<GameObject>();
    void Awake()
    {
        instance = this;
        //objPrefab = Resources.Load<GameObject>("Bullet6");
        Init();
    }
    //存放子弹
    public void Init()
    {
        PoolManager poolManager = objPrefab.GetComponent<PoolManager>();
        if (poolManager != null)
        {
            for (int i = 0; i < initCount; i++)
            {
                //存储子弹到弹夹中
                GameObject obj = GameObject.Instantiate(objPrefab);
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
        initCount = 60;
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
            result = GameObject.Instantiate(objPrefab);
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