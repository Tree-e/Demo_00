using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Test_button1 : MonoBehaviour
{
    public static Test_button1 instance;

    Transform Skill;

    float cdT1;
    float onClickT1;
    bool isDo1 = false;
    int dotime1;
    Image image1;
    Image mask1;
    Text cd1;
    Button skill1;

    float cdT2;
    float onClickT2;
    bool isDo2 = false;
    int dotime2;
    Image image2;
    Image mask2;
    Text cd2;
    Button skill2;

    Button pause;
    Text showTime;
    Text score;

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

    float start;

    int playerLevel;
    float playerEX;
    float MaxEX;
    private void Awake()
    {
        playerLevel = PlayerPrefs.GetInt("Level");
        playerEX = PlayerPrefs.GetInt("EX");
        MaxEX = 1000;
        //testInit();
        instance = this;
    }
    void Start()
    {
        Skill = transform.Find("Message");

        skill1 = transform.Find("Message/Skill1/Button").GetComponent<Button>();
        skill1.onClick.AddListener(DO1);
        image1 = transform.Find("Message/Skill1/Button").GetComponent<Image>();
        mask1 = transform.Find("Message/Skill1/Image").GetComponent<Image>();
        cd1 = transform.Find("Message/Skill1/Image/Text").GetComponent<Text>();

        skill2 = transform.Find("Message/Skill2/Button").GetComponent<Button>();
        skill2.onClick.AddListener(DO2);
        image2 = transform.Find("Message/Skill2/Button").GetComponent<Image>();
        mask2 = transform.Find("Message/Skill2/Image").GetComponent<Image>();
        cd2 = transform.Find("Message/Skill2/Image/Text").GetComponent<Text>();

        showTime = transform.Find("Message/Time").GetComponent<Text>();
        score = transform.Find("Message/Score").GetComponent<Text>();

        pause = transform.Find("Message/Pause_Bt").GetComponent<Button>();
        pause.onClick.AddListener(gamepasue);

        Pause = transform.Find("Pause");
        Continue_Bt = transform.Find("Pause/Continue_Button").GetComponent<Button>();
        Continue_Bt.onClick.AddListener(gameContinue);
        PauseMenu = transform.Find("Pause/Menu_Button").GetComponent<Button>();
        PauseMenu.onClick.AddListener(backMenu);
        Again = transform.Find("Pause/TryAgain_Button").GetComponent<Button>();
        Again.onClick.AddListener(gameAgain);

        Failed = transform.Find("Failed");
        FailedBack = transform.Find("Failed/Back_Button").GetComponent<Button>();
        FailedBack.onClick.AddListener(backMenu);
        FailedAgian = transform.Find("Failed/TryAgain_Button").GetComponent<Button>();
        FailedAgian.onClick.AddListener(gameAgain);
        FailedScore = transform.Find("Failed/Score/Score_Text").GetComponent<Text>();
        FailedLevel = transform.Find("Failed/Level").GetComponent<Text>();
        FailedEX = transform.Find("Failed/Level/Ex_percent").GetComponent<Text>();
        FailedEX_img = transform.Find("Failed/Level/EX_Img").GetComponent<Image>();

        Win = transform.Find("Win");
        WinBack = transform.Find("Win/Back_Button").GetComponent<Button>();
        WinBack.onClick.AddListener(backMenu);
        Next = transform.Find("Win/Next_Button").GetComponent<Button>();
        WinAgian = transform.Find("Win/TryAgain_Button").GetComponent<Button>();
        WinAgian.onClick.AddListener(gameAgain);
        WinScore = transform.Find("Win/Score/Score_Text").GetComponent<Text>();
        WinLevel = transform.Find("Win/Level").GetComponent<Text>();
        WinEX = transform.Find("Win/Level/Ex_percent").GetComponent<Text>();
        WinEX_img = transform.Find("Win/Level/EX_Img").GetComponent<Image>();

        init();
        
    }
    
    void Update()
    {
        showTime.text = "  Time: " + Math.Round(Time.time - start, 2);
        score.text = "  Score: " + Ship_atb.ship_Atb.getscore();
        Nor();
        keyDown();
    }

    private void FixedUpdate()
    {
        //timescale=0时update会继续跑，所以放里面会反复执行；
        if (Ship_atb.ship_Atb.blood <= 0)
        {
            gameFailed(); 
        }
        if (Time.time - start > 60 || EnemyManager.enemyManager.getwin())
        {
            gameWin();
        }
    }
    void keyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DO1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DO2();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gamepasue();
        }
    }
    void Nor()
    {
        Nor1(isDo1);
        Nor2(isDo2);
    }
    void Nor1(bool DO)
    {
        if (DO)
        {
            if (dotime1 == 1)
            {
                Ship_atb.ship_Atb.Skill1();
                dotime1 = 0;
            }
            mask1.gameObject.SetActive(true);
            //Debug.Log("123455");
            if (onClickT1 < cdT1)
            {
                onClickT1 += Time.deltaTime;
                mask1.fillAmount = 1 - onClickT1 / cdT1;
                cd1.text = "" + Math.Round(cdT1 - onClickT1,1);
                if (mask1.fillAmount <= 0.01)
                {
                    mask1.gameObject.SetActive(false);
                    notDO1();
                    onClickT1 = 0;
                }
            }
        }
        
    }
    void Nor2(bool DO)
    {
        if (DO)
        {
            mask2.gameObject.SetActive(true);
            //Debug.Log("123455");
            if (onClickT2 < cdT2)
            {
                onClickT2 += Time.deltaTime;
                mask2.fillAmount = 1 - onClickT2 / cdT2;
                cd2.text = "" + Math.Round(cdT2 - onClickT2, 1);
                if(onClickT2 < 5 && dotime2 == 1)
                {
                    Bullet_go.bullet_go.setskillup(true);
                    dotime2 = 2;
                }
                else if(onClickT2 >=5 && dotime2 == 2)
                {
                    Bullet_go.bullet_go.setskillup(false);
                    dotime2 = 0;
                }
                if (mask2.fillAmount <= 0.01)
                {
                    mask2.gameObject.SetActive(false);
                    notDO2();
                    onClickT2 = 0;
                }
            }
        }

    }
    void init()
    {
        Time.timeScale = 1;
        start = Time.time;

        Pause.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Failed.gameObject.SetActive(false);

        getSkillImage();
        SkillInit();
    }
    public void backMenu()
    {
        SceneManager.LoadScene(0);
        //UIManager.uiManager.showMenu();
        Time.timeScale = 1;
    }
    void gamepasue()
    {
        Time.timeScale = 0;
        Pause.gameObject.SetActive(true);
        Skill.gameObject.SetActive(false);
    }
    public void gameContinue()
    {
        Time.timeScale = 1;
        Pause.gameObject.SetActive(false);
        Skill.gameObject.SetActive(true);
    }
    public void gameAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        init();
        //Ship_atb.ship_Atb.init();
    }
    public void gameFailed()
    {
        Time.timeScale = 0;
        Failed.gameObject.SetActive(true);
        Skill.gameObject.SetActive(false);
        Updateex();
        FailedScore.text = "" + Ship_atb.ship_Atb.getscore();
        FailedEX.text = "EX: " + getex() + " / " + initex();
        FailedLevel.text = "LV: " + getlv();
        FailedEX_img.fillAmount = Mathf.Lerp(0, 1, getex() / initex());
        UpdateData();
        //Debug.Log(Mathf.Lerp(0, 1, getex() / initex()));
        //Debug.Log(FailedEX_img.fillAmount);
    }
    void gameWin()
    {
        Time.timeScale = 0;
        Win.gameObject.SetActive(true);
        Skill.gameObject.SetActive(false);
        Updateex();
        WinScore.text = "" + Ship_atb.ship_Atb.getscore();
        WinEX.text = "EX: " + getex() + " / " + initex();
        WinLevel.text = "LV: " + getlv();
        WinEX_img.fillAmount = Mathf.Lerp(0, 1, getex() / initex());
        UpdateData();
    }
    void DO1()
    {
        isDo1 = true;
        dotime1 = 1;
    }
    void notDO1()
    {
        isDo1 = false;   
    }
    void DO2()
    {
        isDo2 = true;
        dotime2 = 1;
    }
    void notDO2()
    {
        isDo2 = false;
    }

    public int getlv()
    {
        return playerLevel;
    }
    //public int Updatelv(int lv)
    //{
    //    playerLevel = lv;
    //    //Debug.Log(level);
    //    return playerLevel;
    //}
    public void Updateex()
    {
        playerEX = PlayerPrefs.GetFloat("EX");
        playerEX += Ship_atb.ship_Atb.getscore() * 10;
    }
    public float getex()
    {
        while (playerEX >= initex())
        {
            playerEX -= initex();
            playerLevel++;
            Debug.Log(PlayerPrefs.GetInt("SkillPoint"));
            PlayerPrefs.SetInt("SkillPoint", PlayerPrefs.GetInt("SkillPoint") + 1);
            Debug.Log(PlayerPrefs.GetInt("SkillPoint"));
            if (playerEX < initex())
            {
                break;
            }
        }
        return playerEX;
    }
    public float initex()
    {
        return MaxEX;
    }
    void UpdateData()
    {
        PlayerPrefs.SetInt("Level", getlv());
        PlayerPrefs.SetFloat("EX", getex());
    }
    void testInit()
    {
        playerLevel = 15;
        playerEX = 500;
    }
    void getSkillImage()
    {
        image1.sprite = Resources.Load<Sprite> ("skill/" + PlayerPrefs.GetString("UseShipName") + "-S1");
        image2.sprite = Resources.Load<Sprite>("skill/" + PlayerPrefs.GetString("UseShipName") + "-S2");
    }
    void SkillInit()
    {
        Skill.gameObject.SetActive(true);

        mask1.gameObject.SetActive(false);
        mask1.fillAmount = 1;
        cdT1 = 5;
        mask2.gameObject.SetActive(false);
        mask2.fillAmount = 1;
        cdT2 = 10;
    }
}
