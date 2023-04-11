using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class ElietControl : MonoBehaviour
{
    Rigidbody Rig;
    GameObject Bullt;
    Transform firePoint;

    //float fireTime = 0.5f;
    float waitTime = 10f;

    Vector3[] pt1;
    Vector3[] pt2;

    Tween DOMove;

    BoxCollider[] boxcollider;
    //float speed = 50f;

    //Vector3 dir = Vector3.back;
    //private float LastingTime;

    //GameObject Des_Enemyship;

    void Start()
    {
        Rig = this.GetComponent<Rigidbody>();
        Rig.useGravity = false;
        //Rig.velocity = dir * speed;
        Bullt = Resources.Load<GameObject>("Bullet5");
        //LastingTime = fireTime;
        firePoint = transform.Find("FirePoint");

        //Des_Enemyship = Resources.Load<GameObject>("explosion_enemy");

        if (this.transform.position.x > 0)
        {
            pt1 = Getpt(0);
            pt2 = Getpt(2);
        }
        else
        {
            pt1 = Getpt(1);
            pt2 = Getpt(3);
        }
        StartCoroutine(Move(pt1, pt2));
        boxcollider = this.GetComponents<BoxCollider>();
    }

    void Update()
    {
        if (EnemyManager.enemyManager.elbloods[this.transform.name] <= 0)
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
        //    GameObject gobullet = Instantiate<GameObject>(Bullt);
        //    gobullet.transform.position = firePoint.position;
        //    LastingTime = Time.time + fireTime;
        //}
        //if (this.transform.position.z <= 40)
        //{
        //    speed = 1;
        //    Rig.velocity = dir * speed;
        //}
        //if (Time.time >= 50)
        //{
        //    speed = 150;
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
    IEnumerator Move(Vector3[] pt1, Vector3[] pt2)
    {
        DOMove = this.transform.DOPath(pt1, 2f, PathType.CatmullRom).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(waitTime);
        DOMove = this.transform.DOPath(pt2, 5f, PathType.Linear).SetEase(Ease.Linear);
    }

    Vector3[] Getpt(int time)
    {
        Vector3[] pt = new Vector3[2];
        switch (time)
        {
            case 0:
                pt[0] = this.transform.position;
                pt[1] = new Vector3(32, 5, 15);
                break;
            case 1:
                pt[0] = this.transform.position;
                pt[1] = new Vector3(-32, 5, 15);
                break;
            case 2:
                pt[0] = new Vector3(32, 5, 15);
                pt[1] = new Vector3(32, 5, -130);
                break;
            case 3:
                pt[0] = new Vector3(-32, 5, 15);
                pt[1] = new Vector3(-32, 5, -130);
                break;
            default:
                break;
        }
        //if (time == 1)
        //{
        //    pt[0] = new Vector3(-100, 5, -50);
        //    pt[1] = new Vector3(100, 5, -50);
        //}
        //else if (time == 2)
        //{
        //    pt[0] = new Vector3(-100, 5, -50);
        //    pt[1] = new Vector3(-100, 5, -50);
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
    }
}
