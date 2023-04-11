using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSettings : MonoBehaviour
{
    public Toggle FullScreen_Toggle;
    public Toggle Window_Toggle;
    public Toggle BGM_Toggle;
    public Toggle Sound_Toggle;
    public Button Back_Button;
    void Start()
    {
        FullScreen_Toggle = GameObject.Find("FullScreen_Toggle").GetComponent<Toggle>();
        Window_Toggle = GameObject.Find("Window_Toggle").GetComponent<Toggle>();
        BGM_Toggle = GameObject.Find("BGM_Toggle").GetComponent<Toggle>();
        Sound_Toggle = GameObject.Find("Sound_Toggle").GetComponent<Toggle>();
        Back_Button = GameObject.Find("Back_Button").GetComponent<Button>();

        DontDestroyOnLoad(GameUI.Instance);

        Back_Button.onClick.AddListener(BackMenu);
    }
    public void BackMenu()
    {
        GameUI.Instance.ShowPanel(1);
    }

    void Update()
    {
        
    }
}
