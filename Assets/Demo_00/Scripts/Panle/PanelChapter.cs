using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChapter : MonoBehaviour
{
    public Button Chapter1;
    public Button Chapter2;
    public Button Chapter3;
    public Button Chapter4;
    public Button Chapter5;
    public Button BackMenu;
    public ScrollRect ChapterVertical1;
    public ScrollRect ChapterVertical2;
    public ScrollRect ChapterVertical3;
    public ScrollRect ChapterVertical4;
    public ScrollRect ChapterVertical5;


    void Start()
    {
        Chapter1 = GameObject.Find("Chapter1").GetComponent<Button>();
        Chapter2 = GameObject.Find("Chapter2").GetComponent<Button>();
        Chapter3 = GameObject.Find("Chapter3").GetComponent<Button>();
        Chapter4 = GameObject.Find("Chapter4").GetComponent<Button>();
        Chapter5 = GameObject.Find("Chapter5").GetComponent<Button>();
        BackMenu = GameObject.Find("Back_Button").GetComponent<Button>();
        ChapterVertical1 = GameObject.Find("ChapterVertical1").GetComponent<ScrollRect>();
        ChapterVertical2 = GameObject.Find("ChapterVertical2").GetComponent<ScrollRect>();
        ChapterVertical3 = GameObject.Find("ChapterVertical3").GetComponent<ScrollRect>();
        ChapterVertical4 = GameObject.Find("ChapterVertical4").GetComponent<ScrollRect>();
        ChapterVertical5 = GameObject.Find("ChapterVertical5").GetComponent<ScrollRect>();
        DontDestroyOnLoad(GameUI.Instance);
        Chapter1.onClick.AddListener(Choose1);
        Chapter2.onClick.AddListener(Choose2);
        Chapter3.onClick.AddListener(Choose3);
        Chapter4.onClick.AddListener(Choose4);
        Chapter5.onClick.AddListener(Choose5);
        BackMenu.onClick.AddListener(backMenu);
    }

    void Update()
    {
        
    }
    public void Choose1()
    {
        ChooseChapter(1);
    }
    public void Choose2()
    {
        ChooseChapter(2);
    }
    public void Choose3()
    {
        ChooseChapter(3);
    }
    public void Choose4()
    {
        ChooseChapter(4);
    }
    public void Choose5()
    {
        ChooseChapter(5);
    }
    public void backMenu()
    {
        GameUI.Instance.ShowPanel(1);
    }
    public void ChooseChapter(int num)
    {
        switch (num)
        {
            case 1:
                ChapterVertical1.gameObject.SetActive(true);
                ChapterVertical2.gameObject.SetActive(false);
                ChapterVertical3.gameObject.SetActive(false);
                ChapterVertical4.gameObject.SetActive(false);
                ChapterVertical5.gameObject.SetActive(false);
                break;
            case 2:
                ChapterVertical1.gameObject.SetActive(false);
                ChapterVertical2.gameObject.SetActive(true);
                ChapterVertical3.gameObject.SetActive(false);
                ChapterVertical4.gameObject.SetActive(false);
                ChapterVertical5.gameObject.SetActive(false);
                break;
            case 3:
                ChapterVertical1.gameObject.SetActive(false);
                ChapterVertical2.gameObject.SetActive(false);
                ChapterVertical3.gameObject.SetActive(true);
                ChapterVertical4.gameObject.SetActive(false);
                ChapterVertical5.gameObject.SetActive(false);
                break;
            case 4:
                ChapterVertical1.gameObject.SetActive(false);
                ChapterVertical2.gameObject.SetActive(false);
                ChapterVertical3.gameObject.SetActive(false);
                ChapterVertical4.gameObject.SetActive(true);
                ChapterVertical5.gameObject.SetActive(false);
                break;
            case 5:
                ChapterVertical1.gameObject.SetActive(false);
                ChapterVertical2.gameObject.SetActive(false);
                ChapterVertical3.gameObject.SetActive(false);
                ChapterVertical4.gameObject.SetActive(false);
                ChapterVertical5.gameObject.SetActive(true);
                break;
        }
    }
}
