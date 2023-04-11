using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliet_bulletpool_manager : MonoBehaviour, Bulletpool
{
    public void getinpool()
    {
        Debug.Log("精英子弹进仓");
    }
    public void getoutpool()
    {
        Debug.Log("精英子弹出仓");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Eliet_bulletpool.eliet_Bulletpool.Recycle(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            ShipHp.shipHp.Updateblood(Ship_atb.ship_Atb.behit(Enemy_atb.enemy_Atb.attk));
            Eliet_bulletpool.eliet_Bulletpool.Recycle(this.gameObject);
        }
    }
}
