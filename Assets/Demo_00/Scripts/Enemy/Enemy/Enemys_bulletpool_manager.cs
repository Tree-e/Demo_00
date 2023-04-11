using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Bulletpool
{
    void getinpool();
    void getoutpool();
}
public class Enemys_bulletpool_manager : MonoBehaviour, Bulletpool
{
    public void getinpool()
    {
        Debug.Log("敌机子弹装填");
    }
    public void getoutpool()
    {
        Debug.Log("敌机子弹回收");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Enemys_bulletpool.enemys_Bulletpool.Recycle(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            ShipHp.shipHp.Updateblood(Ship_atb.ship_Atb.behit(Enemy_atb.enemy_Atb.attk));
            Enemys_bulletpool.enemys_Bulletpool.Recycle(this.gameObject);
        }
    }
}
