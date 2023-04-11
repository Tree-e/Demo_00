using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Test_Qu : MonoBehaviour
{
    Vector3[] path1 = new Vector3[9];
    //GameObject[] Tags = new GameObject[9];
    [Header("终点")]
    public GameObject tag8;
    Tweener tweenPath;
    [Header("曲线点1")]
    public GameObject tag1;
    [Header("曲线点2")]
    public GameObject tag2;
    [Header("曲线点3")]
    public GameObject tag3;
    [Header("起点到终点的总时间")]
    public float speed;
    [Header("延迟多少秒开始")]
    public float times;
    Vector3 tag0;
    GameObject tag4;
    GameObject tag5;
    GameObject tag6;
    GameObject tag7;
    // Start is called before the first frame update
    private void Awake()
    {
        tag8 = new GameObject("Tag8");
        tag1 = new GameObject("Tag1");
        tag2 = new GameObject("Tag2");
        tag3 = new GameObject("Tag3");
        tag4 = new GameObject("Tag4");
        tag5 = new GameObject("Tag5");
        tag6 = new GameObject("Tag6");
        tag7 = new GameObject("Tag7");
        tag8.transform.position = new Vector3(0, 0, 0);
        tag2.transform.position = new Vector3(10, 0, 10);
        tag4.transform.position = new Vector3(0, 0, 20);
        tag6.transform.position = new Vector3(-10, 0, 10);
        tag1.transform.position = new Vector3(7.1f, 0, 2.9f);
        tag3.transform.position = new Vector3(7.1f, 0, 17.1f);
        tag5.transform.position = new Vector3(-7.1f, 0, 17.1f);
        tag7.transform.position = new Vector3(-7.1f, 0, 2.9f);
        tag0 = this.transform.position;
    }
    void Start()
    {
        StartCoroutine(StayFuction());
    }
    IEnumerator StayFuction()
    {
        yield return new WaitForSeconds(times);
        path1[0] = tag0;//起始点
        path1[1] = tag1.transform.position;
        path1[2] = tag2.transform.position;
        path1[3] = tag3.transform.position;
        path1[4] = tag4.transform.position;//终点
        path1[5] = tag5.transform.position;
        path1[6] = tag6.transform.position;
        path1[7] = tag7.transform.position;
        path1[8] = tag8.transform.position;
        tweenPath = this.transform.DOPath(path1, speed, PathType.CatmullRom).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 20, 120, 30), "重新运行"))
    //    {
    //        this.transform.position = pos;
    //        tweenPath.Kill();
    //        StopAllCoroutines();
    //        StartCoroutine(StayFuction());
    //    }
    //}
}
