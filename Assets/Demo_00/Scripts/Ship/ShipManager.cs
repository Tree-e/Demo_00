using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    GameObject preShip;
    void Start()
    {
        preShip = Resources.Load<GameObject>(PlayerPrefs.GetString("UseShipName"));
        StartCoroutine(CreatShip());
    }

    void Update()
    {
        //Test_button1.instance.Updateex();
    }
    IEnumerator CreatShip()
    {
        GameObject player = Instantiate(preShip);
        //Ship_atb.ship_Atb.init();
        player.transform.position = new Vector3(0, 5, -42);

        yield return null;
    }
}
