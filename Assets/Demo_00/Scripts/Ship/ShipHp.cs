using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHp : MonoBehaviour
{
    public static ShipHp shipHp;
    private Slider hpSlider;
    private RectTransform hpRecTrans;

    public Transform target;
    public Vector3 offsetPos = new Vector3(0,0,-5.11f);
    //float value = 0.1f;
    //float maxblood = 1f;

    private void Awake()
    {
        shipHp = this;
    }

    void Start()
    {
        hpSlider = transform.Find("Slider").GetComponent<Slider>();
        hpRecTrans = GetComponent<RectTransform>();
        //target = ShipMove.Instance.transform;
        Init(Ship_atb.ship_Atb.blood, Ship_atb.ship_Atb.initblood());
    }

    void Update()
    {
        //if (target == null)
        //    return;
        //hpRecTrans.position = target.transform.position + offsetPos;

        //if (Time.time > 3)
        //    hpSlider.value = value / maxblood;
    }
    void Init(float blood, float maxblood)
    {
        hpSlider.maxValue = maxblood;
        hpSlider.value = blood;
    }
    public void Updateblood(float hp)
    {
        hpSlider.value = hp;
    }
}
