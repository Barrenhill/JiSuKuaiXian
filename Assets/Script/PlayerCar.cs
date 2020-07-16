using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : CarBase
{

    /// <summary>
    /// 玩家武器模型（1级）
    /// </summary>
    public GameObject PlayerGunLeve1;
    /// <summary>
    /// 玩家武器模型（2级）
    /// </summary>
    public GameObject PlayerGunLeve2;
    /// <summary>
    /// 玩家武器模型（3级）
    /// </summary>
    public GameObject PlayerGunleve3;
    /// <summary>
    /// 发射子弹的初始位置
    /// </summary>
    public Transform LaunchPosition;
    /// <summary>
    /// 子弹预设体
    /// </summary>
    public GameObject Bullet;

    public GameControl GameControl;
    [Range(0,2)]public int armsleve;
    /// <summary>
    /// 玩家数据
    /// </summary>
    public PlayerDate Date;

    
    
    /// <summary>
    /// 动画播放器
    /// </summary>
    private Animator _anim;

    /// <summary>
    /// 发射子弹的CD计时器
    /// </summary>
    private float _timer;

    private void Start()
    {
        health = maxHealth = 50;
        SetArms(ArmsLeve.Gun1);
        Date.IntervalTime = 0.1f;
    }

    private void FixedUpdate()
    {
        if (Date.ArmsLeve != armsleve)
        {
            switch (armsleve)
            {
                case (int)ArmsLeve.Gun1:
                    SetArms(ArmsLeve.Gun1);
                    break;
                case (int)ArmsLeve.Gun2:
                    SetArms(ArmsLeve.Gun2);
                    break;
                case (int)ArmsLeve.Gun3:
                    SetArms(ArmsLeve.Gun3);
                    break;
            }
        }
        PlayerMove();
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            switch (Date.ArmsLeve)
            {
                case (int)ArmsLeve.Gun1:
                    LaunchBullet(Bullet,Quaternion.identity, LaunchPosition.position,(int) ArmsLeve.Gun1 + 1,0.11f);
                    break;
                case (int)ArmsLeve.Gun2:
                    LaunchBullet(Bullet,Quaternion.identity, LaunchPosition.position,(int) ArmsLeve.Gun2 + 1,0.11f);
                    break;
                case (int)ArmsLeve.Gun3:
                    LaunchBullet(Bullet,Quaternion.identity, LaunchPosition.position,(int) ArmsLeve.Gun3 + 1,0.11f);
                    break;
            }
            _timer = Date.IntervalTime;
        }
    }
    
    /// <summary>
    /// 玩家移动控制
    /// </summary>
    public void PlayerMove()
    {
        //获取鼠标按下时的位置并转为世界坐标
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //获取鼠标位置
            Date.WorldPressPosition = Camera.main.ScreenToWorldPoint(MousePressPosition); //将鼠标位置转为世界坐标
            Date.PlayerPosition = transform.position; //获取玩家位置
        }

        //获取鼠标的实时位置并转为世界坐标
        if (GameControl.Instance.MouseDownStatus)
        {
            Date.MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //获取鼠标在屏幕上的坐标
            Date.WorldPosition = Camera.main.ScreenToWorldPoint(Date.MousePosition); //将屏幕坐标转换为世界坐标
            Vector3 Position;
            Position.x = Mathf.Clamp(Date.PlayerPosition.x + (Date.WorldPosition.x - Date.WorldPressPosition.x), -2,
                2); //计算玩家目标点的X轴坐标
            Position.y = transform.position.y;
            Position.z = transform.position.z;
            transform.position = Position;
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag.Equals(Tag.Enemy))
    {
        Attack(other.gameObject);
    }
}
/// <summary>
/// 收到攻击
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
public override void BeAttack(int value)
{
    base.BeAttack(value);
    if (IsDeath())
    {
        Destroy(gameObject);
    } 
}

    /// <summary>
    /// 设置武器的等级
    /// </summary>
    /// <param name="leve"></param>
    void SetArms(ArmsLeve leve)
    {
        //根据武器的等级切换对应的模型
        switch (leve)
        {
            case ArmsLeve.Gun1:
                PlayerGunLeve1.SetActive(true);
                PlayerGunLeve2.SetActive(false);
                PlayerGunleve3.SetActive(false);
                _anim = PlayerGunLeve1.transform.Find("Gun").GetComponent<Animator>();
                break;
            case ArmsLeve.Gun2:
                PlayerGunLeve1.SetActive(false);
                PlayerGunLeve2.SetActive(true);
                PlayerGunleve3.SetActive(false);
                _anim = PlayerGunLeve2.transform.Find("Gun").GetComponent<Animator>();
                break;
            case ArmsLeve.Gun3:
                PlayerGunLeve1.SetActive(false);
                PlayerGunLeve2.SetActive(false);
                PlayerGunleve3.SetActive(true);
                _anim = PlayerGunleve3.GetComponentInChildren<Animator>();
                break;
        }
            _anim.SetInteger("Gun", (int) leve);//播放对应枪械等级的动画
            Date.ArmsLeve = (int) leve;
    }
}
