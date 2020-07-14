using UnityEngine;
using System.Collections;

public class ButtleRun : MonoBehaviour
{
    //子弹的运行速度
    private float m_buttleSpeed = 10.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //子弹跑起来
        GameButtleRun();
    }
    void OnTriggerEnter( Collider other )
    {
        Debug.Log("触碰");
        if (other.gameObject.CompareTag(Tags.g_Wall))
        {
            gameObject.SetActive(false);
        }
    }

    void GameButtleRun()
    {
        transform.position += transform.forward * m_buttleSpeed * Time.deltaTime;
    }
}