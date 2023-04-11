using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelMenu : MonoBehaviour
{
    public Button Start_Button;
    public Button Ships_Button;
    public Button Settings_Button;
    public Button Exit_Button;
    void Start()
    {
        Start_Button = GameObject.Find("Start_Button").GetComponent<Button>();
        Ships_Button = GameObject.Find("Ships_Button").GetComponent<Button>();
        Settings_Button = GameObject.Find("Settings_Button").GetComponent<Button>();
        Exit_Button = GameObject.Find("Exit_Button").GetComponent<Button>();


        //Start_Button.onClick.AddListener(ShowChapter);
        Ships_Button.onClick.AddListener(ShowShips);
        Settings_Button.onClick.AddListener(ShowSettings);
        Exit_Button.onClick.AddListener(Exit);

    }

    void Update()
    {
        
    }

    public void ShowShips()
    {
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(GameUI.Instance);
        GameUI.Instance.ShowPanel(2);
    }
    public void ShowSettings()
    {
        GameUI.Instance.ShowPanel(3);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
