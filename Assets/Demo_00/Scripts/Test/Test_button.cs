using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Test_button : MonoBehaviour
{
    float cdT;
    float onClickT;
    float start;
    bool isDo = false;
    Button skill;
    Image mask;
    Text cd;
    Text showTime;
    
    void Start()
    {
        skill = transform.Find("GameObject/Button").GetComponent<Button>();
        skill.onClick.AddListener(DO);
        mask = transform.Find("GameObject/Image").GetComponent<Image>();
        cd = transform.Find("GameObject/Image/Text").GetComponent<Text>();

        showTime = transform.Find("Text").GetComponent<Text>();

        Time.timeScale = 1;
        init();
    }
    
    void Update()
    {
        showTime.text = "" + Math.Round(Time.time - start, 2);
        click(isDo);
        keyDown();
    }
    void keyDown()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DO();
        }
    }
    void click(bool DO)
    {
        if (DO)
        {
            mask.gameObject.SetActive(true);
            Debug.Log("123455");
            //Ship_atb.ship_Atb.Skill1();
            if (onClickT < cdT)
            {
                onClickT += Time.fixedDeltaTime;
                mask.fillAmount = 1 - onClickT / cdT;
                cd.text = "" + Math.Round(cdT - onClickT,1);
                if (mask.fillAmount <= 0)
                {
                    mask.gameObject.SetActive(false);
                    notDO();
                    onClickT = 0;
                }
            }
        }
        
    }
    void init()
    {
        mask.gameObject.SetActive(false);
        mask.fillAmount = 1;
        cdT = 5;
        start = Time.time;
    } 
    void DO()
    {
        isDo = true;
    }
    void notDO()
    {
        isDo = false;   
    }
}
