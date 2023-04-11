using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[RequireComponent(typeof(Rigidbody))]
public class ShipMove : MonoBehaviour
{
    //飞船移动速度
    float speed = 100f;
    //飞船刚体
    Rigidbody rig;
    //玩家移动范围
    float minX = -55f;
    float maxX = 55f;
    float minZ = -66f;
    float maxZ = 66f;
    //出射点
    //Transform transFirePoint;
    //
    //GameObject prefabGoBullet;
    //声音
    //GameObject Des_Player;
    //初始化飞船生命
    //const int lifeMax = 5;
    //int curLife;
    //int curScore;
    //
    //Vector3 world;
    //
    //private float bullet_time;
    //
    //private float nexttime;
    //将类单例处理
    private static ShipMove instance;

    public static ShipMove Instance
    {
        get
        {
            return instance;
        }
    }


    //生命属性（对curLife字段的封装）
    //public int CurLife
    //{
    //    get
    //    {
    //        return curLife;
    //    }
    //    set
    //    {
    //        curLife = value;
    //        //对UI界面数据的更新
    //        //GameUI.Instance.updateLife(curLife);
    //    }
    //}
    //得分属性（对curScore字段的封装）
    //public int CurScore
    //{
    //    get
    //    {
    //        return curScore;
    //    }
    //    set
    //    {
    //        curScore = value;
    //        //对UI界面数据的更新
    //        //GameUI.Instance.updateScore(curScore);
    //    }
    //}
    //
    //public float Bullet_time
    //{
    //    get
    //    {
    //        return bullet_time;
    //    }
    //    set
    //    {
    //        bullet_time = value;
    //    }
    //}

    private void Awake()
    {
        //加载此类
        instance = this;
    }
    void Start()
    {
        //定位飞船
        //transform.position = new Vector3(0, 5, -42);
        //获取飞船上的刚体
        rig = GetComponent<Rigidbody>();
        //禁用重力
        rig.useGravity = false;
        //找到子弹发射位置
        //transFirePoint = transform.Find("BulletPoint");
        //加载子弹预制体
        //prefabGoBullet = Resources.Load<GameObject>("Bullet6");
        //更新下一次执行时间点
        //nextTime = Time.time + BulletDeltaTime;
        //加载飞船摧毁声音
        //Des_Player = Resources.Load<GameObject>("explosion_player");
        //初始化数据
        //CurLife = lifeMax;
        //CurScore = 0;
        //Bullet_time = 0.3f;
    }
    //碰撞检测
    /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameBody.tagenemyship) || other.CompareTag(GameBody.tagstone) || other.CompareTag(GameBody.tagenemybullet))
            {
                if (Des_Player)
                {
                    GameObject des_player = Instantiate(Des_Player, transform.position, Quaternion.identity);
                    Destroy(des_player, 1f);
                }
                curLife -= 1;
                //通过生命值判断对象是否可被销毁
                ShipMove.Instance.CurLife = curLife;
                if (curLife == 0)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    this.gameObject.SetActive(false);
                    StartCoroutine(back_to_game());
                }
            }
        }
        IEnumerator back_to_game()
        {
            yield return new WaitForSeconds(1f);
            ShipMove.Instance.transform.position = new Vector3(PlayerManager.Instance.X, PlayerManager.Instance.Y, PlayerManager.Instance.Z);
            this.gameObject.SetActive(true);
        }
    */
    private void Update()
    {
        //while (Time.time >= nexttime){
        //    //GameObject goBullet = Instantiate<GameObject>(prefabGoBullet);
        //    //goBullet.transform.position = transFirePoint.position;
        //    Bullet_pool.instance.GetObject();
        //    nexttime = Time.time + Bullet_time;
        //}
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    if (Time.time >= nexttime)
        //    {
        //        GameObject goBullet = Instantiate<GameObject>(prefabGoBullet);
        //        goBullet.transform.position = transFirePoint.position;
        //        nexttime = Time.time + Bullet_time;
        //    }

        //}
        //Vector3 targetposition = Camera.main.WorldToScreenPoint(this.transform.position);
        //Vector3 mouseposition = Input.mousePosition;
        //if (Input.GetMouseButton(0))
        //{
        //    mouseposition.z = targetposition.z;
        //    world.x = Camera.main.ScreenToWorldPoint(mouseposition).x;
        //    world.z = Camera.main.ScreenToWorldPoint(mouseposition).z;
        //    world.y = this.transform.position.y;
        //    speed = 20;
        //}
        //if (this.transform.position == world)
        //    speed = 0;
        //this.transform.LookAt(world);
        //this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed);
        if (rig)
        {
            rig.velocity = new Vector3(h, 0, v) * speed;
            //rig.constraints = RigidbodyConstraints.FreezeRotationZ;
            //rig.angularVelocity = new Vector3(0, 0, -30) * h;
        }
        //transform.eulerAngles = new Vector3(0, 0, 10);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        transform.position = position;
    }
}