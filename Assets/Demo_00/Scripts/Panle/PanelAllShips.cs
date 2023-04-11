using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAllShips : MonoBehaviour
{
    public GameObject AtlasChoose;
    public GameObject ShipManager;
    public GameObject ShipMessage;
    public Button Your;
    public Button Enemy;
    public Button ChooseBack;
    public Button Normal;
    public Button Model1_1;
    public Button Model1_2;
    public Button Model2_1;
    public Button Model2_2;
    public Button Model3_1;
    public Button Model3_2;
    public Button Model4_1;
    public Button Model4_2;
    public Button ShipManagerBack;
    public Button ShipUp;
    public Button Skill1Up;
    public Button Skill2Up;
    public Button ShipMessageBack;


    void Start()
    {
        AtlasChoose = GameObject.Find("AtlasChoose").GetComponent<GameObject>();
        ShipManager = GameObject.Find("ShipManager").GetComponent<GameObject>();
        ShipMessage = GameObject.Find("ShipMessage").GetComponent<GameObject>();
        Your = GameObject.Find("Your").GetComponent<Button>();
        Enemy = GameObject.Find("Enemy").GetComponent<Button>();
        ChooseBack = GameObject.Find("ChooseBack").GetComponent<Button>();
        Normal = GameObject.Find("Normal").GetComponent<Button>();
        Model1_1 = GameObject.Find("Model1_1").GetComponent<Button>();
        Model1_2 = GameObject.Find("Model1_2").GetComponent<Button>();
        Model2_1 = GameObject.Find("Model2_1").GetComponent<Button>();
        Model2_2 = GameObject.Find("Model2_2").GetComponent<Button>();
        Model3_1 = GameObject.Find("Model3_1").GetComponent<Button>();
        Model3_2 = GameObject.Find("Model3_2").GetComponent<Button>();
        Model4_1 = GameObject.Find("Model4_1").GetComponent<Button>();
        Model4_2 = GameObject.Find("Model4_2").GetComponent<Button>();
        ShipManagerBack = GameObject.Find("ShipManagerBack").GetComponent<Button>();
        ShipUp = GameObject.Find("ShipUp").GetComponent<Button>();
        Skill1Up = GameObject.Find("Skill1Up").GetComponent<Button>();
        Skill2Up = GameObject.Find("Skill2Up").GetComponent<Button>();
        ShipMessageBack = GameObject.Find("ShipMessageBack").GetComponent<Button>();

        DontDestroyOnLoad(GameUI.Instance);

        Your.onClick.AddListener(setShipMa);
        ChooseBack.onClick.AddListener(backMenu);
        Normal.onClick.AddListener(setShipMe);
        Model1_1.onClick.AddListener(setShipMe);
        Model1_2.onClick.AddListener(setShipMe);
        Model2_2.onClick.AddListener(setShipMe);
        Model3_1.onClick.AddListener(setShipMe);
        Model3_2.onClick.AddListener(setShipMe);
        Model4_1.onClick.AddListener(setShipMe);
        Model4_2.onClick.AddListener(setShipMe);
        ShipManagerBack.onClick.AddListener(backAtlas);
        ShipMessageBack.onClick.AddListener(backShipMa);
        
    }

    void Update()
    {
        
    }
    public void setAtlase()
    {
        choosePanel(1);
    }
    public void setShipMa()
    {
        choosePanel(2);
    }
    public void setShipMe()
    {
        choosePanel(3);
    }
    public void backMenu()
    {
        GameUI.Instance.ShowPanel(1);
    }
    public void backAtlas()
    {
        choosePanel(1);
    }
    public void backShipMa()
    {
        choosePanel(2);
    }
    public void choosePanel(int num)
    {
        switch (num)
        {
            case 1:
                AtlasChoose.gameObject.SetActive(true);
                ShipManager.gameObject.SetActive(false);
                ShipMessage.gameObject.SetActive(false);
                break;
            case 2:
                AtlasChoose.gameObject.SetActive(false);
                ShipManager.gameObject.SetActive(true);
                ShipMessage.gameObject.SetActive(false);
                break;
            case 3:
                AtlasChoose.gameObject.SetActive(false);
                ShipManager.gameObject.SetActive(false);
                ShipMessage.gameObject.SetActive(true);
                break;
        }
    }
}
