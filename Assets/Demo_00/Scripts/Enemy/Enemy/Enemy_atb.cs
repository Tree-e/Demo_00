using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_atb : MonoBehaviour
{
    public static Enemy_atb enemy_Atb;

    public float blood;
    //Dictionary<string,float> bloods = new Dictionary<string,float>();
    public float attk;
    public float Maxblood;
    BoxCollider[] boxcollider;

    private void Awake()
    {
        enemy_Atb = this;
    }

    public void init(GameObject set1)
    {
        boxcollider = this.GetComponents<BoxCollider>();
        for (int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[i].enabled = false;
        }
        Maxblood = 30;
        attk = 3;
        blood = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().maxValue = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().value = blood;
    }

    public float behit(string name)
    {
        //Debug.Log(name);
        //Debug.Log(bloods[name]);
        blood = EnemyManager.enemyManager.enbloods[name];
        blood -= Ship_atb.ship_Atb.attk;
        EnemyManager.enemyManager.enbloods[name] = blood;
        return blood;
    }
    public void Updateblood(GameObject behit, float hp)
    {
        behit.transform.Find("Canvas/Slider").GetComponent<Slider>().value = hp;
    }
}
