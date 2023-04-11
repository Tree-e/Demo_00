using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_atb : MonoBehaviour
{
    public static Ship_atb ship_Atb;

    int level = 1;
    public float blood;
    public int score;
    int speed;

    //int Maxex;
    public int attk;
    public float Maxblood;

    private void Awake()
    {
        init();
        UpdateData();
        //Debug.Log(speed);
        ship_Atb = this;
    }

    void Update()
    {
        //Updateex();
    }
    public void Skill1()
    {
        blood += 5;
        if (blood > Maxblood)
        {
            blood = Maxblood;
        }
        ShipHp.shipHp.Updateblood(blood);
    }
    public void init()
    {
        score = 0;
        //level = 1;
        attk = 6;
        Maxblood = 20;
        blood = Maxblood;
        setspeed(150);
    }
    public void addscore()
    {
        score += 1;
    }
    public int getscore()
    {
        return score;
    }
    public float behit(float attk)
    {
        blood -= attk;
        return blood;
    }
    //public int getlv()
    //{
    //    return level;
    //}
    //public int Updatelv(int lv)
    //{
    //    level = lv;
    //    //Debug.Log(level);
    //    return level;
    //}
    //public void Updateex()
    //{
    //    ex = getscore() * 10;
    //}
    //public float getex()
    //{
    //     while(ex >= initex())
    //    {
    //        ex -= initex();
    //        level++;
    //        if(ex < initex())
    //        {
    //            break;
    //        }
    //    }
    //    return ex;
    //}
    public float initblood()
    {
        return Maxblood;
    }
    //public float initex()
    //{
    //    return Maxex;
    //}

    //public void UpdateData()
    //{
    //    PlayerPrefs.SetInt("Level", level);
    //    PlayerPrefs.SetFloat("EX", ex);
    //}
    //void ReadData()
    //{
    //    level = PlayerPrefs.GetInt("Level");
    //    ex = PlayerPrefs.GetFloat("EX");
    //}
    public void setspeed(int s)
    {
        speed = s;
    }
    public int getspeed()
    {
        return speed;
    }
    void UpdateData()
    {
        PlayerPrefs.SetInt("Normal_LV", level);
        PlayerPrefs.SetFloat("Normal_BL", Maxblood);
        PlayerPrefs.SetFloat("Normal_SP", speed);
        PlayerPrefs.SetFloat("Normal_ATK", attk);
    }
}
