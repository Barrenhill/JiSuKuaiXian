using UnityEngine;
using System.Collections;

public class CreateButtle : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("创建子弹");
            //得到子弹
            GameObject buttle = GameObjectManager._Instance.GetGameObjectInDic(GameObjectName.g_ButtleName);
            buttle.transform.position = GameObject.Find("Gun/Position").transform.position;
        }
    }
}