using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_bulletpool : MonoBehaviour
{
    public static Enemys_bulletpool enemys_Bulletpool;
    public int initCount;
    public GameObject bulletPre;
    public Queue<GameObject> queue = new Queue<GameObject>();

    public void Awake()
    {
        enemys_Bulletpool = this;
    }
    private void Start()
    {
        //Debug.Log(this.transform.parent.name);
        //Debug.Log(this.transform.parent.gameObject.name);
        //Debug.Log(this.transform.parent.transform.name);
        Init();
    }
    public void Init()
    {
        initCount = 10;
        Bulletpool bulletpool = bulletPre.GetComponent<Bulletpool>();
        if (bulletpool != null)
        {
            for (int i = 0; i < initCount; i++)
            {
                //存储子弹到弹夹中
                GameObject obj = GameObject.Instantiate(bulletPre);
                obj.name = this.transform.parent.name + i;
                //obj.name = "enemy";
                //obj.transform.position = new Vector3(10000,10000, 10000);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
        }
        else
        {
            Debug.Log("子弹不对，初始化失败");
            return;
        }
    }
    public GameObject Getbullet()
    {
        GameObject result;
        if (queue.Count >= 1)
        {
            result = queue.Dequeue();
            result.SetActive(true);
            result.GetComponent<Bulletpool>().getoutpool();
        }
        else
        {
            result = GameObject.Instantiate(bulletPre);
            result.GetComponent<Bulletpool>().getoutpool();
        }
        return result;
    }
    public void Recycle(GameObject obj)
    {
        Bulletpool bulletpool = obj.GetComponent<Bulletpool>();
        if (bulletpool != null)
        {
            obj.SetActive(false);
            bulletpool.getinpool();
            queue.Enqueue(obj);
        }
    }
    public void destroy()
    {
        GameObject temp;
        while(queue != null)
        {
            temp = queue.Dequeue();
            Destroy(temp);
        }
    }
}
