using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class EnemyControl : MonoBehaviour
{
    Rigidbody rig;
    //float fireTime = 0.5f;
    float waitTime = 3f;
    //float speed = 50f;

    Vector3[] pt1;
    Vector3[] pt2;
    //Vector3 dir = Vector3.back;
    //GameObject Des_Enemyship;

    BoxCollider[] boxcollider;

    Tween DOMove;

    void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody>();
        rig.useGravity = false;
        //Des_Enemyship = Resources.Load<GameObject>("explosion_enemy");

        if (this.transform.position.x > 0)
        {
            pt1 = Getpt(1);
            pt2 = Getpt(3);
        }
        else
        {
            pt1 = Getpt(2);
            pt2 = Getpt(4);
        }
        StartCoroutine(Move(pt1, pt2));
        boxcollider = this.GetComponents<BoxCollider>();
    }

    void Update()
    {
        if(EnemyManager.enemyManager.enbloods[this.transform.name] <= 0)
        {
            Destroythis();
        }
        if (this.transform.position.z < 80)
        {
            for (int i = 0; i < boxcollider.Length; i++)
            {
                boxcollider[i].enabled = true;
            }
        }
    }

    IEnumerator Move(Vector3[] pt1, Vector3[] pt2)
    {
        DOMove = this.transform.DOPath(pt1, 2f, PathType.Linear).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(waitTime);
        DOMove = this.transform.DOPath(pt2, 5f, PathType.CatmullRom).SetEase(Ease.Linear);
    }
   Vector3[] Getpt(int time)
    {
        //GameObject[] Gpt = new GameObject[pt.Length];
        //for(int i = 0; i < pt.Length; i++)
        //{
        //    Gpt[i] = new GameObject();
        //    Gpt[i].name = "Gpt" + i.ToString();
        //}

        Vector3[] pt = new Vector3[2];
        switch (time)
        {
            case 1:
                pt[0] = this.transform.position;
                pt[1] = new Vector3(pt[0].x, 5, 15);
                break;
            case 2:
                pt[0] = this.transform.position;
                pt[1] = new Vector3(pt[0].x, 5, 15);
                break;
            case 3:
                pt[0] = new Vector3(pt[0].x, 5, -15);
                pt[1] = new Vector3(-100, 5, -50);
                break;
            case 4:
                pt[0] = new Vector3(pt[0].x, 5, -15);
                pt[1] = new Vector3(100, 5, -50);
                break;
            default:
                break;
        }
        //if(time == 1)
        //{
        //    pt[0] = this.transform.position;
        //    pt[1] = new Vector3(-100, 5, -50);
        //}
        //else if(time == 2)
        //{
        //    pt[0] = this.transform.position;
        //    pt[1] = new Vector3(100, 5, -50);
        //}
        //else
        //{
        //    pt[0] = this.transform.position;
        //    pt[1] = new Vector3(-16, 5, 15);
        //}
        
        return pt;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroythis();
        }
    }
    void Destroythis()
    {
        //Destroy(this.GetComponent<Enemys_bulletpool>());
        Destroy(this.gameObject);
        //Enemys_bulletpool.enemys_Bulletpool.destroy();
    }
}
