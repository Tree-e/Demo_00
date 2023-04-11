using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyManager;
    float[] X = {32, -32, 100, -100};
    //float minZ = 115f;
    //float maxZ = 130f;
    float Z = 110f;
    GameObject Enemy1Prefab;
    GameObject Eliet1Prefab;
    GameObject Boss1Prefab;
    int EnemyCount = 10;//每波多少个敌人
    int ElietCount = 2;
    bool isWin = false;
    float EnemyTimeCount = 1.5f;//每个敌人间隔时间
    float ElietTimeCount = 1.5f;

    public Dictionary<string, float> enbloods = new Dictionary<string, float>();
    //public Dictionary<string, Queue<GameObject>> enbulletpool = new Dictionary<string, Queue<GameObject>>();
    public Dictionary<string, float> elbloods = new Dictionary<string, float>();

    public Queue<GameObject>[] qqq;
    private void Awake()
    {
        enemyManager = this;
    }
    void Start()
    {
        //EnemyCount = Random.Range(10, 15);
        //EnemyTimeCount = 1f;
        Enemy1Prefab = Resources.Load<GameObject>("Enemy1");
        //ElietCount = Random.Range(5, 8);
        //ElietTimeCount = Random.Range(2f, 2.3f);
        Eliet1Prefab = Resources.Load<GameObject>("Eliet1");
        Boss1Prefab = Resources.Load<GameObject>("Boss1");
        //Debug.Log(EnemyCount);
        //Debug.Log(ElietCount);

        StartCoroutine(creatEnemy());
        StartCoroutine(creatEliet());
        StartCoroutine(creatBoss());
    }
    IEnumerator creatEnemy()
    {
        yield return new WaitForSeconds(1f);
        for (int j = 0; j < EnemyCount; j++)
        {
            GameObject Enemy1 = Instantiate(Enemy1Prefab);
            Enemy1.name = "enemy0" + j;
            //Debug.Log(Enemy1.name);
            Enemy_atb.enemy_Atb.init(Enemy1);
            enbloods.Add(Enemy1.name, Enemy_atb.enemy_Atb.blood);
            //Enemy_atb.enemy_Atb.num = j;
            //qqq[j] = new Queue<GameObject>();

            //enbulletpool.Add(Enemy1.name, new Queue<GameObject>());
            //Enemys_bulletpool.enemys_Bulletpool.Init(enbulletpool[Enemy1.name]);
            if (j <= 4)
            {
                Enemy1.transform.position = new Vector3(X[0], 5, Z);
            }
            else
            {
                Enemy1.transform.position = new Vector3(X[1], 5, Z);
            }
            yield return new WaitForSeconds(EnemyTimeCount);//生成每一个 的间隔时间
        }
    }
    IEnumerator creatEliet()
    {
        yield return new WaitForSeconds(18f);
        for (int j = 0; j < ElietCount; j++)
        {
            GameObject Eliet1 = Instantiate(Eliet1Prefab);
            Eliet1.name = "eliet0" + j;
            Eliet_atb.eliet_Atb.init(Eliet1);
            elbloods.Add(Eliet1.name, Eliet_atb.eliet_Atb.blood);
            if (j < 1)
            {
                Eliet1.transform.position = new Vector3(X[2], 5, Z);
            }
            else
            {
                Eliet1.transform.position = new Vector3(X[3], 5, Z);
            }
            //Debug.Log(Eliet1.name);
            yield return new WaitForSeconds(ElietTimeCount);//生成每一个 的间隔时间
        }
    }
    IEnumerator creatBoss()
    {
        yield return new WaitForSeconds(32f);
        GameObject Boss1 = Instantiate(Boss1Prefab);
        Boss_atb.boss_Atb.init(Boss1);
        float x = 0;
        Boss1.transform.position = new Vector3(x, 5, Z);
    }

    public void win()
    {
        isWin = true;
    }
    public bool getwin()
    {
        return isWin;
    }
}
