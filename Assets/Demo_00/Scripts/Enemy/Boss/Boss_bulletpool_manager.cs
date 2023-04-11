using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bulletpool_manager : MonoBehaviour, Bulletpool
{
    public void getinpool()
    {
        Debug.Log("boss子弹进仓");
    }
    public void getoutpool()
    {
        Debug.Log("boss子弹进仓");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Boss_bulletpool.boss_Bulletpool.Recycle(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            ShipHp.shipHp.Updateblood(Ship_atb.ship_Atb.behit(Enemy_atb.enemy_Atb.attk));
            Boss_bulletpool.boss_Bulletpool.Recycle(this.gameObject);
        }
    }
}
