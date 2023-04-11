using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    PanelMenu Menu;
    PanelAllShips AllShips;
    PanelSettings Settings;
    PanelChapter Chapter;
    PanelWin Win;
    PanelFailed Failed;
    PanelPause Pause;
    private static GameUI instance;
    public static GameUI Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;

        Menu = transform.Find("Menu").GetComponent<PanelMenu>();
        AllShips = transform.Find("AllShips").GetComponent<PanelAllShips>();
        Settings = transform.Find("Settings").GetComponent<PanelSettings>();
        //Chapter = GameObject.FindGameObjectWithTag("PanelChapter").GetComponent<PanelChapter>();
        //Win = GameObject.FindGameObjectWithTag("PanelWin").GetComponent<PanelWin>();
        // Failed = GameObject.FindGameObjectWithTag("PanelFailed").GetComponent<PanelFailed>();
        // Pause = GameObject.FindGameObjectWithTag("PanelPause").GetComponent<PanelPause>();
        this.ShowPanel(1);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ShowPanel(int num)
    {
        switch(num)
        {
            case 1:
                Menu.gameObject.SetActive(true);
                AllShips.gameObject.SetActive(false);
                Settings.gameObject.SetActive(false);
                break;
            case 2:
                Menu.gameObject.SetActive(false);
                AllShips.gameObject.SetActive(true);
                Settings.gameObject.SetActive(false);
                break;
            case 3:
                Menu.gameObject.SetActive(false);
                AllShips.gameObject.SetActive(false);
                Settings.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
