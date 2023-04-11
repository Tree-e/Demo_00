using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    int playerLevel;
    float playerEX;
    float MaxEX;
    string UseShipName;

    Transform Menu;
    Button Start_Bt;
    Button Ships_Bt;
    Button Settings_Bt;
    Button Exit_Bt;
    Button Player;
    Button Remake;
    Text PlayerLV;
    Text SkillPoint;

    Transform AllShips;
    Button Your_Bt;
    Button Enemy_Bt;
    Button ShipsBack_Bt;

    Transform Settings;
    Button SettingsBack_Bt;
    Toggle FullScreen;
    Toggle Window;
    Toggle BGM;
    Toggle Sound;
    Slider BGM_Sl;
    Slider Sound_Sl;

    Transform EnemyMessage;
    Button EnemyMessageBack_bt;

    Transform ShipsManager;
    Button Normal;
    Button Use_Nor;
    Text Normal_LV;
    Button Model1;
    Button Use1;
    Text Model1_LV;
    Button Model2;
    Button Use2;
    Text Model2_LV;
    Button Model3;
    Button Use3;
    Text Model3_LV;
    Button Model4;
    Button Use4;
    Text Model4_LV;
    Button ShipsManagerBack_Bt;

    Transform ShipMessage;
    Image Shipshow;
    Button ShipUP;
    Button Skill1;
    Button Skill2;
    Button ShipMessageBack_Bt;
    Text ShipName;
    Text HP;
    Text ATK;
    Text FS;
    Text ShipLV;
    Text CD;
    Text Des;

    Transform Chapter;
    Button ChapterBack_Bt;

    Transform ChapterHorizontal;
    GridLayoutGroup Chaptercount;
    Button Chapter1;
    Button Chapter2;
    Button Chapter3;
    Button Chapter4;
    Button Chapter5;

    Transform ChapterVertical1;
    Button Chapter1_1;
    Button Chapter1_2;
    Button Chapter1_3;
    Button Chapter1_4;
    Button Chapter1_5;

    Transform ChapterVertical2;
    Button Chapter2_1;
    Button Chapter2_2;
    Button Chapter2_3;
    Button Chapter2_4;
    Button Chapter2_5;

    Transform ChapterVertical3;
    Button Chapter3_1;
    Button Chapter3_2;
    Button Chapter3_3;
    Button Chapter3_4;
    Button Chapter3_5;

    Transform ChapterVertical4;
    Button Chapter4_1;
    Button Chapter4_2;
    Button Chapter4_3;
    Button Chapter4_4;
    Button Chapter4_5;

    Transform ChapterVertical5;
    Button Chapter5_1;
    Button Chapter5_2;
    Button Chapter5_3;
    Button Chapter5_4;
    Button Chapter5_5;

    private void Awake()
    {
        uiManager = this;
    }


    void Start()
    {
        /*var canvas = GameObject.Find("GameUI");
        Menu = canvas.transform.Find("Menu");
        AllShips = canvas.transform.Find("AllShips");
        Ships_Bt = canvas.transform.Find("Menu/Ships_Button").GetComponent<Button>();
        Ships_Bt.onClick.AddListener(toships);*/
        Menu = transform.Find("Menu");
        Player = transform.Find("Menu/Player").GetComponent<Button>();
        Player.onClick.AddListener(toShipsManager);
        PlayerLV = transform.Find("Menu/Player/PlayerLV/PlayerLV").GetComponent<Text>();
        SkillPoint = transform.Find("Menu/Player/SkillPoint/text").GetComponent<Text>();
        Start_Bt = transform.Find("Menu/Start_Button").GetComponent<Button>();
        Start_Bt.onClick.AddListener(toChapter);
        Ships_Bt = transform.Find("Menu/Ships_Button").GetComponent<Button>();
        Ships_Bt.onClick.AddListener(toShips);
        Settings_Bt = transform.Find("Menu/Settings_Button").GetComponent<Button>();
        Settings_Bt.onClick.AddListener(toSettings);
        Exit_Bt = transform.Find("Menu/Exit_Button").GetComponent<Button>();
        Exit_Bt.onClick.AddListener(Exit);
        Remake = transform.Find("Menu/Remake").GetComponent<Button>();
        Remake.onClick.AddListener(remakeData);

        AllShips = transform.Find("AllShips");
        Your_Bt = transform.Find("AllShips/Your").GetComponent<Button>();
        Your_Bt.onClick.AddListener(toShipsManager);
        Enemy_Bt = transform.Find("AllShips/Enemy").GetComponent<Button>();
        Enemy_Bt.onClick.AddListener(toEnemy);
        ShipsBack_Bt = transform.Find("AllShips/ShipsBack_Button").GetComponent<Button>();
        ShipsBack_Bt.onClick.AddListener(showMenu);

        EnemyMessage = transform.Find("EnemyMessage");
        EnemyMessageBack_bt = transform.Find("EnemyMessage/EnemyMessageBack_Button").GetComponent<Button>();
        EnemyMessageBack_bt.onClick.AddListener(showMenu);

        Settings = transform.Find("Settings");
        FullScreen = transform.Find("Settings/Size/FullScreen").GetComponent<Toggle>();
        Window = transform.Find("Settings/Size/Window").GetComponent<Toggle>();
        BGM = transform.Find("Settings/BGM/BGM_Toggle").GetComponent<Toggle>();
        Sound = transform.Find("Settings/Sound/Sound_Toggle").GetComponent<Toggle>();
        BGM_Sl = transform.Find("Settings/BGM/Slider").GetComponent<Slider>();
        Sound_Sl = transform.Find("Settings/Sound/Slider").GetComponent<Slider>();
        SettingsBack_Bt = transform.Find("Settings/SettingsBack_Button").GetComponent<Button>();
        SettingsBack_Bt.onClick.AddListener(showMenu);

        ShipsManager = transform.Find("ShipsManager");
        Normal = transform.Find("ShipsManager/Scroll View/Viewport/Content/Normal").GetComponent<Button>();
        Normal.onClick.AddListener(getNormal);
        Use_Nor = transform.Find("ShipsManager/Scroll View/Viewport/Content/Normal/Choose").GetComponent<Button>();
        Use_Nor.onClick.AddListener(UseNormal);
        Normal_LV = transform.Find("ShipsManager/Scroll View/Viewport/Content/Normal/LV").GetComponent<Text>();

        Model1 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model1").GetComponent<Button>();
        Model1.onClick.AddListener(getModel1);
        Use1 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model1/Choose").GetComponent<Button>();
        Use1.onClick.AddListener(UseModel1);
        Model1_LV = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model1/LV").GetComponent<Text>();

        Model2 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model2").GetComponent<Button>();
        Model2.onClick.AddListener(getModel2);
        Use2 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model2/Choose").GetComponent<Button>();
        Use2.onClick.AddListener(UseModel2);
        Model2_LV = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model2/LV").GetComponent<Text>();

        Model3 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model3").GetComponent<Button>();
        Model3.onClick.AddListener(getModel3);
        Use3 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model3/Choose").GetComponent<Button>();
        Use3.onClick.AddListener(UseModel3);
        Model3_LV = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model3/LV").GetComponent<Text>();

        Model4 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model4").GetComponent<Button>();
        Model4.onClick.AddListener(getModel4);
        Use4 = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model4/Choose").GetComponent<Button>();
        Use4.onClick.AddListener(UseModel4);
        Model4_LV = transform.Find("ShipsManager/Scroll View/Viewport/Content/Model4/LV").GetComponent<Text>();

        ShipsManagerBack_Bt = transform.Find("ShipsManager/ShipManagerBack_Button").GetComponent<Button>();
        ShipsManagerBack_Bt.onClick.AddListener(showMenu);

        ShipMessage = transform.Find("ShipMessage");
        Shipshow = transform.Find("ShipMessage/UseingShips/ShowShip").GetComponent<Image>();
        ShipUP = transform.Find("ShipMessage/UseingShips/ShipUP").GetComponent<Button>();
        ShipUP.onClick.AddListener(upship);
        ShipMessageBack_Bt = transform.Find("ShipMessage/ShipMessageBack_Button").GetComponent<Button>();
        ShipMessageBack_Bt.onClick.AddListener(toShipsManager);
        ShipName = transform.Find("ShipMessage/UseingShips/Name").GetComponent<Text>();
        HP = transform.Find("ShipMessage/UseingShips/HP/Data").GetComponent<Text>();
        ATK = transform.Find("ShipMessage/UseingShips/ATK/Data").GetComponent<Text>();
        FS = transform.Find("ShipMessage/UseingShips/FS/Data").GetComponent<Text>();
        ShipLV = transform.Find("ShipMessage/UseingShips/LV/Data").GetComponent<Text>();
        Skill1 = transform.Find("ShipMessage/Skills/Skill1/Button").GetComponent<Button>();
        Skill2 = transform.Find("ShipMessage/Skills/Skill2/Button").GetComponent<Button>();
        CD = transform.Find("ShipMessage/Skills/Describe/CD").GetComponent<Text>(); ;
        Des = transform.Find("ShipMessage/Skills/Describe/Describe").GetComponent<Text>(); ;


        Chapter = transform.Find("Chapter");
        ChapterBack_Bt = transform.Find("Chapter/ChapterBack_Button").GetComponent<Button>();
        ChapterBack_Bt.onClick.AddListener(showMenu);

        ChapterHorizontal = transform.Find("Chapter/ChapterManager/ChapterHorizontal");
        Chapter1 = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content/Chapter1").GetComponent<Button>();
        Chapter1.onClick.AddListener(showChapter1);
        Chapter2 = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content/Chapter2").GetComponent<Button>();
        Chapter2.onClick.AddListener(showChapter2);
        Chapter3 = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content/Chapter3").GetComponent<Button>();
        Chapter3.onClick.AddListener(showChapter3);
        Chapter4 = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content/Chapter4").GetComponent<Button>();
        Chapter4.onClick.AddListener(showChapter4);
        Chapter5 = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content/Chapter5").GetComponent<Button>();
        Chapter5.onClick.AddListener(showChapter5);
        Chaptercount = transform.Find("Chapter/ChapterManager/ChapterHorizontal/Viewport/Content").GetComponent<GridLayoutGroup>();

        ChapterVertical1 = transform.Find("Chapter/ChapterManager/ChapterVertical1");
        Chapter1_1 = transform.Find("Chapter/ChapterManager/ChapterVertical1/Viewport/Content/Chapter1-1").GetComponent<Button>();
        Chapter1_1.onClick.AddListener(toChapter1_1);
        Chapter1_2 = transform.Find("Chapter/ChapterManager/ChapterVertical1/Viewport/Content/Chapter1-2").GetComponent<Button>();
        Chapter1_3 = transform.Find("Chapter/ChapterManager/ChapterVertical1/Viewport/Content/Chapter1-3").GetComponent<Button>();
        Chapter1_4 = transform.Find("Chapter/ChapterManager/ChapterVertical1/Viewport/Content/Chapter1-4").GetComponent<Button>();
        Chapter1_5 = transform.Find("Chapter/ChapterManager/ChapterVertical1/Viewport/Content/Chapter1-5").GetComponent<Button>();

        ChapterVertical2 = transform.Find("Chapter/ChapterManager/ChapterVertical2");
        Chapter2_1 = transform.Find("Chapter/ChapterManager/ChapterVertical2/Viewport/Content/Chapter2-1").GetComponent<Button>();
        Chapter2_2 = transform.Find("Chapter/ChapterManager/ChapterVertical2/Viewport/Content/Chapter2-2").GetComponent<Button>();
        Chapter2_3 = transform.Find("Chapter/ChapterManager/ChapterVertical2/Viewport/Content/Chapter2-3").GetComponent<Button>();
        Chapter2_4 = transform.Find("Chapter/ChapterManager/ChapterVertical2/Viewport/Content/Chapter2-4").GetComponent<Button>();
        Chapter2_5 = transform.Find("Chapter/ChapterManager/ChapterVertical2/Viewport/Content/Chapter2-5").GetComponent<Button>();

        ChapterVertical3 = transform.Find("Chapter/ChapterManager/ChapterVertical3");
        Chapter3_1 = transform.Find("Chapter/ChapterManager/ChapterVertical3/Viewport/Content/Chapter3-1").GetComponent<Button>();
        Chapter3_2 = transform.Find("Chapter/ChapterManager/ChapterVertical3/Viewport/Content/Chapter3-2").GetComponent<Button>();
        Chapter3_3 = transform.Find("Chapter/ChapterManager/ChapterVertical3/Viewport/Content/Chapter3-3").GetComponent<Button>();
        Chapter3_4 = transform.Find("Chapter/ChapterManager/ChapterVertical3/Viewport/Content/Chapter3-4").GetComponent<Button>();
        Chapter3_5 = transform.Find("Chapter/ChapterManager/ChapterVertical3/Viewport/Content/Chapter3-5").GetComponent<Button>();

        ChapterVertical4 = transform.Find("Chapter/ChapterManager/ChapterVertical4");
        Chapter4_1 = transform.Find("Chapter/ChapterManager/ChapterVertical4/Viewport/Content/Chapter4-1").GetComponent<Button>();
        Chapter4_2 = transform.Find("Chapter/ChapterManager/ChapterVertical4/Viewport/Content/Chapter4-2").GetComponent<Button>();
        Chapter4_3 = transform.Find("Chapter/ChapterManager/ChapterVertical4/Viewport/Content/Chapter4-3").GetComponent<Button>();
        Chapter4_4 = transform.Find("Chapter/ChapterManager/ChapterVertical4/Viewport/Content/Chapter4-4").GetComponent<Button>();
        Chapter4_5 = transform.Find("Chapter/ChapterManager/ChapterVertical4/Viewport/Content/Chapter4-5").GetComponent<Button>();

        ChapterVertical5 = transform.Find("Chapter/ChapterManager/ChapterVertical5");
        Chapter5_1 = transform.Find("Chapter/ChapterManager/ChapterVertical5/Viewport/Content/Chapter5-1").GetComponent<Button>();
        Chapter5_2 = transform.Find("Chapter/ChapterManager/ChapterVertical5/Viewport/Content/Chapter5-2").GetComponent<Button>();
        Chapter5_3 = transform.Find("Chapter/ChapterManager/ChapterVertical5/Viewport/Content/Chapter5-3").GetComponent<Button>();
        Chapter5_4 = transform.Find("Chapter/ChapterManager/ChapterVertical5/Viewport/Content/Chapter5-4").GetComponent<Button>();
        Chapter5_5 = transform.Find("Chapter/ChapterManager/ChapterVertical5/Viewport/Content/Chapter5-5").GetComponent<Button>();

        //testData();
        showMenu();
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetString("UseShipName"));
    }
    void init()
    {
        Time.timeScale = 1;
        //testData();
        if (PlayerPrefs.HasKey("EX") && PlayerPrefs.HasKey("Level"))
        {
            PlayerLV.text = "" + PlayerPrefs.GetInt("Level");
            SkillPoint.text = "" + PlayerPrefs.GetInt("SkillPoint");
        }
        else
        {
            PlayerLV.text = "" + 1;
            SkillPoint.text = "" + 0;
        }
        if (!PlayerPrefs.HasKey("UseShipName"))
        {
            PlayerPrefs.SetString("UseShipName","Normal");
        }
    }
    public void showMenu()
    {
        init();
        Menu.gameObject.SetActive(true);
        Chapter.gameObject.SetActive(false);
        AllShips.gameObject.SetActive(false);
        EnemyMessage.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        ShipsManager.gameObject.SetActive(false);
        ShipMessage.gameObject.SetActive(false);
    }
    public void toChapter()
    {
        initChapter();
        Menu.gameObject.SetActive(false);
        Chapter.gameObject.SetActive(true);
        AllShips.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        ShipsManager.gameObject.SetActive(false);
        ShipMessage.gameObject.SetActive(false);
    }
    public void toShips()
    {
        Menu.gameObject.SetActive(false);
        Chapter.gameObject.SetActive(false);
        AllShips.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        ShipsManager.gameObject.SetActive(false);
        ShipMessage.gameObject.SetActive(false);
    }
    public void toSettings()
    {
        Menu.gameObject.SetActive(false);
        Chapter.gameObject.SetActive(false);
        AllShips.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
        ShipsManager.gameObject.SetActive(false);
        ShipMessage.gameObject.SetActive(false);
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void toShipsManager()
    {
        UpdateUseShip();
        UpdateShipLV();
        Menu.gameObject.SetActive(false);
        Chapter.gameObject.SetActive(false);
        AllShips.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        ShipsManager.gameObject.SetActive(true);
        ShipMessage.gameObject.SetActive(false);
    }
    public void toEnemy()
    {
        AllShips.gameObject.SetActive(false);
        EnemyMessage.gameObject.SetActive(true);
    }
    public void toShipMessage()
    {
        Menu.gameObject.SetActive(false);
        Chapter.gameObject.SetActive(false);
        AllShips.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        ShipsManager.gameObject.SetActive(false);
        ShipMessage.gameObject.SetActive(true);
        //showSelectShip();
    }
    public void showChapter1()
    {
        ChapterVertical1.gameObject.SetActive(true);
        ChapterVertical2.gameObject.SetActive(false);
        ChapterVertical3.gameObject.SetActive(false);
        ChapterVertical4.gameObject.SetActive(false);
        ChapterVertical5.gameObject.SetActive(false);
    }
    public void showChapter2()
    {
        ChapterVertical1.gameObject.SetActive(false);
        ChapterVertical2.gameObject.SetActive(true);
        ChapterVertical3.gameObject.SetActive(false);
        ChapterVertical4.gameObject.SetActive(false);
        ChapterVertical5.gameObject.SetActive(false);
    }
    public void showChapter3()
    {
        ChapterVertical1.gameObject.SetActive(false);
        ChapterVertical2.gameObject.SetActive(false);
        ChapterVertical3.gameObject.SetActive(true);
        ChapterVertical4.gameObject.SetActive(false);
        ChapterVertical5.gameObject.SetActive(false);
    }
    public void showChapter4()
    {
        ChapterVertical1.gameObject.SetActive(false);
        ChapterVertical2.gameObject.SetActive(false);
        ChapterVertical3.gameObject.SetActive(false);
        ChapterVertical4.gameObject.SetActive(true);
        ChapterVertical5.gameObject.SetActive(false);
    }
    public void showChapter5()
    {
        ChapterVertical1.gameObject.SetActive(false);
        ChapterVertical2.gameObject.SetActive(false);
        ChapterVertical3.gameObject.SetActive(false);
        ChapterVertical4.gameObject.SetActive(false);
        ChapterVertical5.gameObject.SetActive(true);
    }

    public void toChapter1_1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void initChapter()
    {
        int num = 0;
        if(PlayerPrefs.GetInt("Level") < 5)
        {
            num = 1;
        }
        else if(PlayerPrefs.GetInt("Level") < 10)
        {
            num = 2;
        }
        else if (PlayerPrefs.GetInt("Level") < 15)
        {
            num = 3;
        }
        else if (PlayerPrefs.GetInt("Level") < 20)
        {
            num = 4;
        }
        else if (PlayerPrefs.GetInt("Level") < 25)
        {
            num = 5;
        }
        else
        {
            num = 5;
        }
        //Debug.Log(num);
        //Debug.Log(PlayerPrefs.GetInt("Level"));
        Chaptercount.constraintCount = num;
        switch (num)
        {
            case 1:
                Chapter1.gameObject.SetActive(true);
                break;
            case 2:
                Chapter1.gameObject.SetActive(true);
                Chapter2.gameObject.SetActive(true);
                break;
            case 3:
                Chapter1.gameObject.SetActive(true);
                Chapter2.gameObject.SetActive(true);
                Chapter3.gameObject.SetActive(true);
                break;
            case 4:
                Chapter1.gameObject.SetActive(true);
                Chapter2.gameObject.SetActive(true);
                Chapter3.gameObject.SetActive(true);
                Chapter4.gameObject.SetActive(true);
                break;
            case 5:
                Chapter1.gameObject.SetActive(true);
                Chapter2.gameObject.SetActive(true);
                Chapter3.gameObject.SetActive(true);
                Chapter4.gameObject.SetActive(true);
                Chapter5.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    
    public void UpdateData()
    {
        PlayerPrefs.SetInt("Level", playerLevel);
        PlayerPrefs.SetFloat("EX", playerEX);
        PlayerPrefs.SetInt("SkillPoint", 0);
        //Debug.Log(PlayerPrefs.GetInt("Level"));
        //Debug.Log(PlayerPrefs.GetInt("EX"));
        init();
    }
    void testData()
    {
        PlayerPrefs.SetInt("Level",16);
        playerLevel = PlayerPrefs.GetInt("Level");
    }
    void remakeData()
    {
        playerEX = 0;
        playerLevel = 1;
        UpdateData();
        PlayerPrefs.SetInt("Normal" + "_LV", 1);
        PlayerPrefs.SetFloat("Normal" + "_BL", 20);
        PlayerPrefs.SetFloat("Normal" + "_SP", 150);
        PlayerPrefs.SetFloat("Normal" + "_ATK", 5);
    }
    void showSelectShip(string name)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            Debug.Log("获得" + name);
            PlayerPrefs.SetString(name, name);
            PlayerPrefs.SetInt(name + "_LV", 1);
            PlayerPrefs.SetFloat(name + "_BL", 20);
            PlayerPrefs.SetFloat(name + "_SP", 150);
            PlayerPrefs.SetFloat(name + "_ATK", 5);
        }
        Shipshow.sprite = Resources.Load<Sprite>("pic/" + name);
        Skill1.image.sprite = Resources.Load<Sprite>("skill/" + name + "-S1");
        Skill2.image.sprite = Resources.Load<Sprite>("skill/" + name + "-S2");
        ShipName.text = PlayerPrefs.GetString(name);
        HP.text = "" + PlayerPrefs.GetFloat(name + "_BL");
        ATK.text = "" + PlayerPrefs.GetFloat(name + "_ATK");
        FS.text = "" + PlayerPrefs.GetFloat(name + "_SP");
        ShipLV.text = "" + PlayerPrefs.GetInt(name + "_LV");
    }
    void UpdateShipData(string name)
    {
        HP.text = "" + PlayerPrefs.GetFloat(name + "_BL");
        ATK.text = "" + PlayerPrefs.GetFloat(name + "_ATK");
        FS.text = "" + PlayerPrefs.GetFloat(name + "_SP");
        ShipLV.text = "" + PlayerPrefs.GetInt(name + "_LV");
    }

    Dictionary<string,string> chooseShip(string str)
    {
        Dictionary<string, string> ShipData = new Dictionary<string, string>();
        ShipData.Add("name", str);
        ShipData.Add("LV", str + "_LV");
        ShipData.Add("BL", str + "_BL");
        ShipData.Add("ATK", str + "_ATK");
        ShipData.Add("SP", str + "_SP");
        return ShipData;
    }
    void getNormal()
    {
        string name = Normal.name;
        //Dictionary<string,string> Data = chooseShip(name);
        showSelectShip(name);
        toShipMessage();
    }
    void getModel1()
    {
        string name = Model1.name;
        //Dictionary<string, string> Data = chooseShip(name);
        showSelectShip(name);
        toShipMessage();
    }
    void getModel2()
    {
        string name = Model2.name;
        //Dictionary<string, string> Data = chooseShip(name);
        showSelectShip(name);
        toShipMessage();
    }
    void getModel3()
    {
        string name = Model3.name;
        //Dictionary<string, string> Data = chooseShip(name);
        showSelectShip(name);
        toShipMessage();
    }
    void getModel4()
    {
        string name = Model4.name;
        //Dictionary<string,string> Data = chooseShip(name);
        showSelectShip(name);
        toShipMessage();
    }
    void UpdateUseShip()
    {
        //PlayerPrefs.SetString("UseShipName", UseShipName);
        if(PlayerPrefs.GetInt("Level") >= 5)
        {
            Use1.interactable = true;
            Text a = Use1.GetComponentInChildren<Text>();
            a.color = new Color(255, 255, 255);
        }
        else
        {
            Use1.interactable = false;
            Text a = Use1.GetComponentInChildren<Text>();
            a.color = new Color(255, 0, 0);
        }
        if(PlayerPrefs.GetInt("Level") >= 10)
        {
            Use2.interactable = true;
            Text a = Use2.GetComponentInChildren<Text>();
            a.color = new Color(255, 255, 255);
        }
        else
        {
            Use2.interactable = false;
            Text a = Use2.GetComponentInChildren<Text>();
            a.color = new Color(255, 0, 0);
        }
        if (PlayerPrefs.GetInt("Level") >= 15)
        {
            Use3.interactable = true;
            Text a = Use3.GetComponentInChildren<Text>();
            a.color = new Color(255, 255, 255);
        }
        else
        {
            Use3.interactable = false;
            Text a = Use3.GetComponentInChildren<Text>();
            a.color = new Color(255, 0, 0);
        }
        if (PlayerPrefs.GetInt("Level") >= 20)
        {
            Use4.interactable = true;
            Text a = Use4.GetComponentInChildren<Text>();
            a.color = new Color(255, 255, 255);
        }
        else
        {
            Use4.interactable = false;
            Text a = Use4.GetComponentInChildren<Text>();
            a.color = new Color(255, 0, 0);
        }
    }
    void UseNormal()
    {
        UseShipName = Normal.name;
        PlayerPrefs.SetString("UseShipName", UseShipName);
    }
    void UseModel1()
    {
        UseShipName = Model1.name;
        PlayerPrefs.SetString("UseShipName", UseShipName);
    }
    void UseModel2()
    {
        UseShipName = Model2.name;
        PlayerPrefs.SetString("UseShipName", UseShipName);
    }
    void UseModel3()
    {
        UseShipName = Model3.name;
        PlayerPrefs.SetString("UseShipName", UseShipName);
    }
    void UseModel4()
    {
        UseShipName = Model4.name;
        PlayerPrefs.SetString("UseShipName", UseShipName);
    }
    void upship()
    {
        //Debug.Log(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_LV");
        if (PlayerPrefs.GetInt("SkillPoint") > 0)
        {   
            PlayerPrefs.SetInt(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_LV", PlayerPrefs.GetInt(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_LV") + 1);
            PlayerPrefs.SetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_BL", PlayerPrefs.GetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_BL") + 10);
            PlayerPrefs.SetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_SP", PlayerPrefs.GetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_SP") + 20);
            PlayerPrefs.SetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_ATK", PlayerPrefs.GetFloat(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text + "_ATK") + 3);
            PlayerPrefs.SetInt("SkillPoint", PlayerPrefs.GetInt("SkillPoint") - 1);
            UpdateShipData(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetInt("SkillPoint"));
        }
        //if (PlayerPrefs.GetInt(ShipUP.transform.parent.Find("Name").GetComponent<Text>().name + "_LV") == 10)
        //{
        //    PlayerPrefs.SetInt(ShipUP.transform.parent.Find("Name").GetComponent<Text>().name + "_LV", 1);
        //}
        
    }
    void isUpShip()
    {
        if (PlayerPrefs.GetInt(ShipUP.transform.parent.transform.Find("Name").GetComponent<Text>().name + "_LV") == 10)
        {
            ShipUP.transform.Find("Text").GetComponent<Text>().text = "Change";
        }
    }
    void UpdateShipLV()
    {
        Normal_LV.text = " LV : " + PlayerPrefs.GetInt("Normal_LV");
        Model1_LV.text = " LV : " + PlayerPrefs.GetInt("Model1_LV");
        Model2_LV.text = " LV : " + PlayerPrefs.GetInt("Model2_LV");
        Model3_LV.text = " LV : " + PlayerPrefs.GetInt("Model3_LV");
        Model4_LV.text = " LV : " + PlayerPrefs.GetInt("Model4_LV");
    }
}
