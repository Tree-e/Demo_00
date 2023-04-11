using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eliet_atb : MonoBehaviour
{
    public static Eliet_atb eliet_Atb;

    public float blood;
    public float attk;

    public float Maxblood;

    BoxCollider[] boxcollider;

    private void Awake()
    {
        eliet_Atb = this;
    }

    public void init(GameObject set1)
    {
        boxcollider = this.GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[i].enabled = false;
        }
        Maxblood = 250;
        attk = 15;
        blood = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().maxValue = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().value = blood;
    }

    public float behit(string name)
    {
        blood = EnemyManager.enemyManager.elbloods[name];
        blood -= Ship_atb.ship_Atb.attk;
        EnemyManager.enemyManager.elbloods[name] = blood;
        return blood;
    }
    
    public void Updateblood(GameObject behit, float hp)
    {
        behit.transform.Find("Canvas/Slider").GetComponent<Slider>().value = hp;
    }
}
