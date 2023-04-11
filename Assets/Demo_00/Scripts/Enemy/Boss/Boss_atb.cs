using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_atb : MonoBehaviour
{
    public static Boss_atb boss_Atb;
    public float blood;
    //Dictionary<string,float> bloods = new Dictionary<string,float>();
    public float attk;
    public float Maxblood;
    BoxCollider[] boxcollider;

    private void Awake()
    {
        boss_Atb = this;
    }

    public void init(GameObject set1)
    {
        boxcollider = this.GetComponents<BoxCollider>();
        for(int i = 0; i < boxcollider.Length; i++)
        {
            boxcollider[i].enabled = false;
        }
        Maxblood = 1000;
        attk = 20;
        blood = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().maxValue = Maxblood;
        set1.transform.Find("Canvas/Slider").GetComponent<Slider>().value = blood;
    }

    public float behit()
    {
        blood -= Ship_atb.ship_Atb.attk;
        return blood;
    }
    public void Updateblood(GameObject behit, float hp)
    {
        behit.transform.Find("Canvas/Slider").GetComponent<Slider>().value = hp;
    }
}
