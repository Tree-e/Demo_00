using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class Test_autocreat : MonoBehaviour
{
    Tween Do;
    Vector3[] Pt;
    private void Awake()
    {
        GetGb();
        Pt =  Rdpt();
    }
    void Start()
    {
        StartCoroutine(Setpt());

    }
    IEnumerator Setpt()
    {
        yield return new WaitForSeconds(1f);

        Do = this.transform.DOPath(Pt, 1f, PathType.CatmullRom).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    void Update()
    {
        
    }
    
    void GetGb()
    {
        GameObject[] Gbs = new GameObject[10];
        for(int i = 0; i < Gbs.Length; i++)
        {
            string name = (string)("Gb"+i.ToString());
            Gbs[i] = new GameObject();
            Gbs[i].name = name;
           //Gbs[i].AddComponent<Rigidbody>();
           //Gbs[i].GetComponent<Rigidbody>().useGravity = false;
        }
    }
    Vector3[] Getpt()
    {
        Vector3[] pt = new Vector3[9];
        pt[0] = new Vector3(0, 0, 0);
        pt[1] = new Vector3(7.1f, 0, 2.9f);
        pt[2] = new Vector3(10, 0, 10);
        pt[3] = new Vector3(7.1f, 0, 17.1f);
        pt[4] = new Vector3(0, 0, 20);
        pt[5] = new Vector3(-7.1f, 0, 17.1f);
        pt[6] = new Vector3(-10, 0, 10);
        pt[7] = new Vector3(-7.1f, 0, 2.9f);
        pt[8] = new Vector3(0, 0, 0);

        return pt;
    }
    Vector3[] Rdpt()
    {
        Vector3[] temp =  Getpt();
        int t = Random.Range(1, 10);
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = temp[i] * t;
        }

        return temp;
    }
}
