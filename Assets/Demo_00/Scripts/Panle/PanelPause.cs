using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour
{
    public Button Menu;
    public Button Continue;
    void Start()
    {
        Menu = GameObject.Find("Menu_Button").GetComponent<Button>();
        Continue = GameObject.Find("Continue_Button").GetComponent<Button>();

        DontDestroyOnLoad(GameUI.Instance);

        Menu.onClick.AddListener(BackMenu);
    }
    public void BackMenu()
    {
        GameUI.Instance.ShowPanel(1);
    }

    void Update()
    {
        
    }
}
