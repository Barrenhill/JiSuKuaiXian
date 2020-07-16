using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCar : CarBase
{
    /// <summary>
    /// 子弹预制体
    /// </summary>
    [SerializeField]private GameObject _bullet;
    /// <summary>
    /// 发射位置
    /// </summary>
    [SerializeField] private Transform _launchPosition;
    /// <summary>
    /// 发射子弹的CD计时器
    /// </summary>
    private float _cdTimer;

    private CarDate _cDete;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = -2;
        health = maxHealth = 30;
        _cDete.IntervalTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        _cdTimer -= Time.deltaTime;
        if (_cdTimer <= 0)
        {
            LaunchBullet(_bullet,new Quaternion(15,90,0,0), _launchPosition.position,3,0.23f);
            _cdTimer = _cDete.IntervalTime;
        }
    }

}
