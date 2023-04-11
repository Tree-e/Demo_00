using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class BossControl : MonoBehaviour
{
    Rigidbody Rig;
    GameObject Bullt5;
    Transform firePoint;
    Vector3[] pt1;
    Vector3[] pt2;
    Vector3[] pt3;
    BoxCollider[] boxcollider;
    Tween DOMove;
    //float fireTime = 0.5f;
    float waitTime1 = 10f;
    float waitTime2 = 10f;
    //float speed = 50f;
    //Vector3 dir = Vector3.back;
    //private float LastingTime;
    //GameObject Des_Enemyship;
    void Start()
    {
        Rig = this.GetComponent<Rigidbody>();
        Rig.useGravity = false;
        //Rig.velocity = dir * speed;
        Bullt5 = Resources.Load<GameObject>("Bullet5");
        //LastingTime = fireTime;
        firePoint = transform.Find("FirePoint");
        //Des_Enemyship = Resources.Load<GameObject>("explosion_enemy");
        pt1 = Getpt(0);
        pt2 = Getpt(2);
        pt3 = Getpt(1);
        StartCoroutine(Move(pt1, pt2, pt3));
        boxcollider = this.GetComponents<BoxCollider>();
    }
    void Update()
    {
        if (Boss_atb.boss_Atb.blood <= 0)
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
        //if (Time.time > LastingTime)
        //{
        //    GameObject gobullet = Instantiate<GameObject>(Bullt5);
        //    gobullet.transform.position = firePoint.position;
        //    LastingTime = Time.time + fireTime;
        //}
        //if (this.transform.position.z <= 40)
        //{
        //    speed = 1;
        //    Rig.velocity = dir * speed;
        //}
        //if (Time.time >= 120)
        //{
        //    speed = 100;
        //    Rig.velocity = dir * speed;
        //}
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(Tags.tagplayerbullet))
    //    {
    //        if (Des_Enemyship)
    //        {
    //            GameObject des_stone = Instantiate(Des_Enemyship, transform.position, Quaternion.identity);
    //            Destroy(des_stone, 2f);
    //        }
    //        Destroy(this.gameObject);
    //    }
    //}
    IEnumerator Move(Vector3[] pt1, Vector3[] pt2, Vector3[] pt3)
    {
        DOMove = this.transform.DOPath(pt1, 2f, PathType.Linear).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(waitTime1);
        DOMove = this.transform.DOPath(pt2, 10f, PathType.CatmullRom).SetEase(Ease.Linear);
        yield return new WaitForSeconds(waitTime2);
        DOMove = this.transform.DOPath(pt3, 3f, PathType.Linear).SetEase(Ease.Linear);
    }
    Vector3[] Getpt(int time)
    {
        
        switch (time)
        {
            case 0:
                Vector3[] pt0 = new Vector3[2];
                pt0[0] = this.transform.position;
                pt0[1] = new Vector3(0, 5, 40);
                return pt0;
            case 1:
                Vector3[] pt1 = new Vector3[2];
                pt1[0] = new Vector3(0, 5, 40);
                pt1[1] = new Vector3(0, 5, -125);
                return pt1;
            case 2:
                Vector3[] pt2 = new Vector3[5];
                pt2[0] = new Vector3(0, 5, 50);
                pt2[1] = new Vector3(-40, 5, 40);
                pt2[2] = new Vector3(0, 5, 30);
                pt2[3] = new Vector3(40, 5, 40);
                pt2[4] = new Vector3(0, 5, 50);
                return pt2;
            default:
                return null;
        }
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
        EnemyManager.enemyManager.win();
        Debug.Log(EnemyManager.enemyManager.getwin());
    }
}
