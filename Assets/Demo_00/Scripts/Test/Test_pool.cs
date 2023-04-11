using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test_pool : MonoBehaviour
{
    //Unity中实现单例的方法  方便访问池子
    public static Test_pool instance;
    //有多少子弹
    public int initCount;
    //进哪种子弹
    public GameObject objPrefab;
    //存放在哪
    public Queue<GameObject> queue = new Queue<GameObject>();
    void Awake()
    {
        instance = this;
        Init();
        //objPrefab = GameObject.Find("Assets/Demo_00/Resources/Bullet7");
        //initCount = 30;
    }
    //存放子弹
    public void Init()
    {
        IPoolObject ipoolObject = objPrefab.GetComponent<IPoolObject>();
        if (ipoolObject != null)
        {
            for (int i = 0; i < initCount; i++)
            {
                //存储子弹到弹夹中
                GameObject obj = Instantiate<GameObject>(objPrefab);
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
            result.GetComponent<IPoolObject>().ExitPool();
        }
        //没货
        else
        {
            result = Instantiate<GameObject>(objPrefab);
            result.GetComponent<IPoolObject>().ExitPool();
        }
        return result;
    }
    //回收子弹
    public void Recycle(GameObject obj)
    {
        IPoolObject ipoolObject = obj.GetComponent<IPoolObject>();
        if (ipoolObject != null)
        {
            //禁止使用
            obj.SetActive(false);
            //初始化
            ipoolObject.EnterPool();
            //存入队列
            queue.Enqueue(obj);
        }
    }
}
