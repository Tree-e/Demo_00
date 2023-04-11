using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayingManager : MonoBehaviour
{
    public static PlayingManager instance;
    Button Pause_Bt;
    Button Skill1;
    Image Mask1;
    Text CD1;
    Button Skill2;
    Image Mask2;
    Text CD2;

    Text Showtime;
    Text Score;

    Transform Pause;
    Button Continue_Bt;
    Button PauseMenu;
    Button Again;

    Transform Win;
    Button WinBack;
    Button Next;
    Button WinAgian;
    Text WinScore;
    Text WinLevel;
    Text WinEX;
    Image WinEX_img;

    Transform Failed;
    Button FailedBack;
    Button FailedAgian;
    Text FailedScore;
    Text FailedLevel;
    Text FailedEX;
    Image FailedEX_img;

    //Transform Message;

    float startTime;
    float skill1OnClickTime;
    float skill2OnClickTime;
    int skill1CDtime;
    int skill2CDtime;
    float skill1PassTime;
    float skill2PassTime;
    bool s1isDO;
    bool s2isDO;
    private void Awake()
    {
        instance = this;
        //Message = this.transform.Find("Message");
        Pause_Bt = this.transform.Find("Pause_Bt").GetComponent<Button>();
        Pause_Bt.onClick.AddListener(gamePause);
        Skill1 = this.transform.Find("GameObject/Button").GetComponent<Button>();
        Mask1 = this.transform.Find("GameObject/Image").GetComponent<Image>();
        CD1 = this.transform.Find("GameObject/Image/Text").GetComponent<Text>();
        Skill2 = this.transform.Find("Message/Skill2/Button").GetComponent<Button>();
        Mask2 = this.transform.Find("Message/Skill2/Image").GetComponent<Image>();
        CD2 = this.transform.Find("Message/Skill2/Image/CD").GetComponent<Text>();
        Skill1.onClick.AddListener(s1DO);
        //Skill2.onClick.AddListener(s2DO);

        Score = this.transform.Find("Score").GetComponent<Text>();
        Showtime = this.transform.Find("Time").GetComponent<Text>();

        Pause = this.transform.Find("Pause");
        Continue_Bt = this.transform.Find("Pause/Continue_Button").GetComponent<Button>();
        Continue_Bt.onClick.AddListener(gameContinue);
        PauseMenu = this.transform.Find("Pause/Menu_Button").GetComponent<Button>();
        PauseMenu.onClick.AddListener(backMenu);
        Again = this.transform.Find("Pause/TryAgain_Button").GetComponent<Button>();
        Again.onClick.AddListener(gameAgain);

        Win = this.transform.Find("Win");
        WinBack = this.transform.Find("Win/Back_Button").GetComponent<Button>();
        WinBack.onClick.AddListener(backMenu);
        Next = this.transform.Find("Win/Next_Button").GetComponent<Button>();
        WinAgian = this.transform.Find("Win/TryAgain_Button").GetComponent<Button>();
        WinAgian.onClick.AddListener(gameAgain);
        WinScore = this.transform.Find("Win/Score").GetComponent<Text>();
        WinLevel = this.transform.Find("Win/Level").GetComponent<Text>();
        WinEX = this.transform.Find("Win/Level/Ex_percent").GetComponent<Text>();
        WinEX_img = this.transform.Find("Win/Level/EX_Img").GetComponent<Image>();

        Failed = this.transform.Find("Failed");
        FailedBack = this.transform.Find("Failed/Back_Button").GetComponent<Button>();
        FailedBack.onClick.AddListener(backMenu);
        FailedAgian = this.transform.Find("Failed/TryAgain_Button").GetComponent<Button>();
        FailedAgian.onClick.AddListener(gameAgain);
        FailedScore = this.transform.Find("Failed/Score/Score_Text").GetComponent<Text>();
        FailedLevel = this.transform.Find("Failed/Level").GetComponent<Text>();
        FailedEX = this.transform.Find("Failed/Level/Ex_percent").GetComponent<Text>();
        FailedEX_img = this.transform.Find("Failed/Level/EX_Img").GetComponent<Image>();

        init();
        Ship_atb.ship_Atb.init();
    }

    void Update()
    {
        Showtime.text = "  Time: " + Math.Round(Time.time - startTime, 2);
        Score.text = "  Score: " + Ship_atb.ship_Atb.getscore();
        if (Ship_atb.ship_Atb.blood <= 0)
        {
            //gameFailed();
        }
        if (Time.time - startTime >= 60)
        {
            //gameWin();
        }
        //if (xInput.GetMouseButton(1))
        //{
        //    skill2time = Time.time;
        //    if((Time.time - skill2time) < 30)
        //    {
        //        Ship_atb.ship_Atb.Updatelv(1);
        //    }
        //}
        s1Click(s1isDO);
        //s2Click(s2isDO);
    }
    void init()
    {
        //Message.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Failed.gameObject.SetActive(false);
        startTime = Time.time;
        Mask1.gameObject.SetActive(false);
        Mask1.fillAmount = 1;
        skill1CDtime = 5;
        Mask2.gameObject.SetActive(false);
        Mask2.fillAmount = 1;
        skill2CDtime = 10;
        s1isDO = false;
        s2isDO = false;
    }
    public void backMenu()
    {
        SceneManager.LoadScene(0);
        //UIManager.uiManager.showMenu();
        Time.timeScale = 1;
    }
    public void gamePause()
    {
        Time.timeScale = 0;
        Pause.gameObject.SetActive(true);
    }
    public void gameContinue()
    {
        Time.timeScale = 1;
        Pause.gameObject.SetActive(false);
    }
    public void gameAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        init();
        Ship_atb.ship_Atb.init();
    }
    
    //public void gameFailed()
    //{
    //    Time.timeScale = 0;
    //    Failed.gameObject.SetActive(true);
    //    FailedScore.text = "" + Ship_atb.ship_Atb.getscore();
    //    FailedEX.text = "EX: " + Ship_atb.ship_Atb.getex() + " / " +Ship_atb.ship_Atb.initex();
    //    FailedLevel.text = "LV: " + Ship_atb.ship_Atb.getlv();
    //    FailedEX_img.fillAmount = Mathf.Lerp(0,1, Ship_atb.ship_Atb.getex() / Ship_atb.ship_Atb.initex()) ;
    //    //Debug.Log(FailedEX_img.fillAmount);
    //}
    //void gameWin()
    //{
    //    Time.timeScale = 0;
    //    Win.gameObject.SetActive(true);
    //    WinScore.text = "" + Ship_atb.ship_Atb.getscore();
    //    WinEX.text = "EX: " + Ship_atb.ship_Atb.getex() + " / " + Ship_atb.ship_Atb.initex();
    //    WinLevel.text = "LV: " + Ship_atb.ship_Atb.getlv();
    //    WinEX_img.fillAmount = Mathf.Lerp(0, 1, Ship_atb.ship_Atb.getex() / Ship_atb.ship_Atb.initex());
    //}
    void s1Click(bool IS)
    {
        if (IS)
        {
            //Ship_atb.ship_Atb.Skill1();
            Mask1.gameObject.SetActive(true);
            if (skill1OnClickTime < skill1CDtime)
            {
                skill1OnClickTime += Time.deltaTime;
                //Debug.Log(skill1OnClickTime);
                //Debug.Log(Time.deltaTime);
                //skill1OnClickTime = Time.time - skill1PassTime;
                Mask1.fillAmount -= skill1OnClickTime / skill1CDtime;
                CD1.text = "" + Math.Round(skill1CDtime - skill1OnClickTime, 1);
                if(Mask1.fillAmount <= 0)
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
    //        UIManager.uiManager.Updatelv(2);
    //        Mask2.gameObject.SetActive(true);
    //        if (skill2OnClickTime < skill2CDtime)
    //        {
    //            skill2OnClickTime = Time.time - skill2PassTime;
    //            Mask2.fillAmount -= skill2OnClickTime / skill2CDtime;
    //            CD2.text = "" + Math.Round(skill2CDtime - skill2OnClickTime, 2);
    //            if(skill2OnClickTime >= 5)
    //            {
    //                UIManager.uiManager.Updatelv(1);
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
        //skill1PassTime = Time.time;
        s1isDO = true;
    }
    void s1notDO()
    {
        s1isDO = false;
    }
    void s2DO()
    {
        skill2PassTime = Time.time;
        s2isDO = true;
    }
    void s2notDO()
    {
        s2isDO = false;
    }
}
