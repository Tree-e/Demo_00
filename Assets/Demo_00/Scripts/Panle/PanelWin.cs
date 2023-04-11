using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : MonoBehaviour
{
    public Button Try_Again;
    public Button Next;
    public Button Back;
    public Text Score;
    public Text Level;
    public Text EX;
    public Image EX_Image;
    void Start()
    {
        Try_Again = GameObject.Find("TryAgain_Button").GetComponent<Button>();
        Next = GameObject.Find("Next_Button").GetComponent<Button>();
        Back = GameObject.Find("TryAgain_Button").GetComponent<Button>();
        Score = GameObject.Find("Score_Text").GetComponent<Text>();
        Level = GameObject.Find("Level").GetComponent<Text>();
        EX = GameObject.Find("Ex_persent").GetComponent<Text>();
        EX_Image = GameObject.Find("EX_Img").GetComponent<Image>();

        DontDestroyOnLoad(GameUI.Instance);

        Back.onClick.AddListener(Back_Menu);
    }

    public void Back_Menu()
    {
        GameUI.Instance.ShowPanel(1);
    }
    void Update()
    {
        
    }
}
