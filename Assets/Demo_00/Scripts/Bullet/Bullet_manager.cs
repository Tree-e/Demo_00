using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PoolManager
{
    void InPool();
    void OutPool();

}
public class Bullet_manager : MonoBehaviour, PoolManager
{
    public void InPool()  // 进仓进行存储
    {
        Debug.Log("进入池子的初始化");
    }
    public void OutPool()     //  出仓
    {
        Debug.Log("退出池子的初始化 -- 获取使用");
    }
    //做碰撞器的物体点一下进行回收
    //void OnMouseDown()
    //{
    //    Bullet_pool.instance.Recycle(this.gameObject);
    //}
    void OnTriggerEnter(Collider other)
    {
        if (this.transform.name == "LV1")
        {
            if (other.CompareTag("Wall"))
            {
                Bullet_pool.instance.Recycle(this.gameObject);
            }
            else if (other.CompareTag("enemy"))
            {
                //Debug.Log(other.transform.parent.transform.parent.name);
                Ship_atb.ship_Atb.addscore();
                Enemy_atb.enemy_Atb.Updateblood(other.transform.gameObject, Enemy_atb.enemy_Atb.behit(other.transform.name));
                //Debug.Log(Ship_atb.ship_Atb.getscore());
                Bullet_pool.instance.Recycle(this.gameObject);
            }
            else if (other.CompareTag("eliet"))
            {
                Ship_atb.ship_Atb.addscore();
                Eliet_atb.eliet_Atb.Updateblood(other.transform.gameObject, Eliet_atb.eliet_Atb.behit(other.transform.name));
                Bullet_pool.instance.Recycle(this.gameObject);
            }
            else if (other.CompareTag("boss"))
            {
                Ship_atb.ship_Atb.addscore();
                Boss_atb.boss_Atb.Updateblood(other.gameObject, Boss_atb.boss_Atb.behit());
                Bullet_pool.instance.Recycle(this.gameObject);
            }
        }
        else if (this.transform.name == "lv2_right")
        {
            if (other.CompareTag("Wall"))
            {
                Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
            }
            else if (other.CompareTag("enemy"))
            {
                Ship_atb.ship_Atb.addscore();
                Enemy_atb.enemy_Atb.Updateblood(other.transform.gameObject, Enemy_atb.enemy_Atb.behit(other.transform.name));
                //Debug.Log(Ship_atb.ship_Atb.getscore());
                Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
            }
            else if (other.CompareTag("eliet"))
            {
                Ship_atb.ship_Atb.addscore();
                Eliet_atb.eliet_Atb.Updateblood(other.transform.gameObject, Eliet_atb.eliet_Atb.behit(other.transform.name));
                Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
            }
            else if (other.CompareTag("boss"))
            {
                Ship_atb.ship_Atb.addscore();
                Boss_atb.boss_Atb.Updateblood(other.gameObject, Boss_atb.boss_Atb.behit());
                Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
            }
        }
        else if (this.transform.name == "lv2_left")
        {
            if (other.CompareTag("Wall"))
            {
                Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
            }
            else if (other.CompareTag("enemy"))
            {
                Ship_atb.ship_Atb.addscore();
                Enemy_atb.enemy_Atb.Updateblood(other.transform.gameObject, Enemy_atb.enemy_Atb.behit(other.transform.name));
                //Debug.Log(Ship_atb.ship_Atb.getscore());
                Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
            }
            else if (other.CompareTag("eliet"))
            {
                Ship_atb.ship_Atb.addscore();
                Eliet_atb.eliet_Atb.Updateblood(other.transform.gameObject, Eliet_atb.eliet_Atb.behit(other.transform.name));
                Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
            }
            else if (other.CompareTag("boss"))
            {
                Ship_atb.ship_Atb.addscore();
                Boss_atb.boss_Atb.Updateblood(other.gameObject, Boss_atb.boss_Atb.behit());
                Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
            }
        }
    }
        //if(this.transform.position.x == 0)
        //{
        //    if (other.CompareTag("Wall"))
        //    {
        //        Bullet_pool.instance.Recycle(this.gameObject);
        //    }
        //    else if (other.CompareTag("enemy") || other.CompareTag("eliet") || other.CompareTag("boss"))
        //    {
        //        Ship_atb.ship_Atb.addscore();
        //        //Debug.Log(Ship_atb.ship_Atb.getscore());
        //        Bullet_pool.instance.Recycle(this.gameObject);
        //    }
        //}
        //else if(this.transform.position.x > 0)
        //{
        //    if (other.CompareTag("Wall"))
        //    {
        //        Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
        //    }
        //    else if (other.CompareTag("enemy") || other.CompareTag("eliet") || other.CompareTag("boss"))
        //    {
        //        Ship_atb.ship_Atb.addscore();
        //        //Debug.Log(Ship_atb.ship_Atb.getscore());
        //        Lv2_pool1.lv2_pool1.Recycle(this.gameObject);
        //    }
        //}
        //else if (this.transform.position.x < 0)
        //{
        //    if (other.CompareTag("Wall"))
        //    {
        //        Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
        //    }
        //    else if (other.CompareTag("enemy") || other.CompareTag("eliet") || other.CompareTag("boss"))
        //    {
        //        Ship_atb.ship_Atb.addscore();
        //        //Debug.Log(Ship_atb.ship_Atb.getscore());
        //        Lv2_pool2.lv2_pool2.Recycle(this.gameObject);
        //    }
        //    
        //}

}
