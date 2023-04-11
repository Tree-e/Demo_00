using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Skill : MonoBehaviour
{
    Button Skill1;
    Image Mask1;
    Text CD1;
    //Button Skill2;
    //Image Mask2;
    //Text CD2;

    float skill1OnClickTime;
    //float skill2OnClickTime;
    int skill1CDtime;
    //int skill2CDtime;
    bool s1isDO;
    //bool s2isDO;
    void Start()
    {
        Skill1 = transform.Find("Skill1/Button").GetComponent<Button>();
        Mask1 = transform.Find("Skill1/Image").GetComponent<Image>();
        CD1 = transform.Find("Skill1/Image/Text").GetComponent<Text>();
        //Skill2 = transform.Find("Skill2/Button").GetComponent<Button>();
        //Mask2 = transform.Find("Skill2/Image").GetComponent<Image>();
        //CD2 = transform.Find("Skill2/Image/CD").GetComponent<Text>();

        Skill1.onClick.AddListener(s1DO);
        //Skill2.onClick.AddListener(s2DO);

        init();
    }

    void Update()
    {
        s1Click(s1isDO);
        //s2Click(s2isDO);
    }
    void init()
    {
        Mask1.gameObject.SetActive(false);
        Mask1.fillAmount = 1;
        skill1CDtime = 5;
        //Mask2.gameObject.SetActive(false);
        //Mask2.fillAmount = 1;
        //skill2CDtime = 10;
        s1isDO = false;
        //s2isDO = false;
    }
    void s1Click(bool IS)
    {
        if (IS)
        {
            Ship_atb.ship_Atb.Skill1();
            Mask1.gameObject.SetActive(true);
            if (skill1OnClickTime <= skill1CDtime)
            {
                skill1OnClickTime += Time.deltaTime;
                //Debug.Log(skill1OnClickTime);
                //Debug.Log(Time.deltaTime);
                //skill1OnClickTime = Time.time - skill1PassTime;
                Mask1.fillAmount -= skill1OnClickTime / skill1CDtime;
                CD1.text = "" + Math.Round(skill1CDtime - skill1OnClickTime, 1);
                if (Mask1.fillAmount <= 0)
                {
                    Mask1.gameObject.SetActive(false);
                    s1notDO();
                    skill1OnClickTime = 0;
                }
            }
        }
    }
    //void s2Click(bool IS)
    //{
    //    if (IS)
    //    {
    //        Ship_atb.ship_Atb.Updatelv(2);
    //        Mask2.gameObject.SetActive(true);
    //        if (skill2OnClickTime < skill2CDtime)
    //        {
    //            skill2OnClickTime += Time.deltaTime;
    //            Mask2.fillAmount -= skill2OnClickTime / skill2CDtime;
    //            CD2.text = "" + Math.Round(skill2CDtime - skill2OnClickTime, 2);
    //            if (skill2OnClickTime >= 5)
    //            {
    //                Ship_atb.ship_Atb.Updatelv(1);
    //            }
    //            if (Mask2.fillAmount <= 0)
    //            {
    //                Mask2.gameObject.SetActive(false);
    //                s2notDO();
    //                skill2OnClickTime = 0;
    //            }
    //        }
    //    }
    //}
    void s1DO()
    {
        s1isDO = true;
    }
    void s1notDO()
    {
        s1isDO = false;
    }
    //void s2DO()
    //{
    //    s2isDO = true;
    //}
    //void s2notDO()
    //{
    //    s2isDO = false;
    //}
}
