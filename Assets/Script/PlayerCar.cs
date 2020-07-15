using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : CarBase
{

    public GameObject GameControl;
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
    public Transform LaunchPosition;
    /// <summary>
    /// 子弹预设体
    /// </summary>
    public GameObject Bullet;

    GameControl _gameControl;

    /// <summary>
    /// 玩家数据
    /// </summary>
    private PlayerDate _date;

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
        _gameControl = GameControl.GetComponent<GameControl>(); //获取游戏控制组件
        SetArms(ArmsLeve.Gun3);
        _date.IntervalTime = 0.2f;
    }

    public PlayerCar(int health, int attack) : base(health, attack)
    {

    }
    private void FixedUpdate()
    {
        PlayerMove();
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            switch (_date.ArmsLeve)
            {
                case (int)ArmsLeve.Gun1:
                    Attack(Bullet,LaunchPosition.position,Quaternion.identity);
                    break;
                case (int)ArmsLeve.Gun2:
                    Attack(Bullet,new Vector3(LaunchPosition.position.x+0.055f,LaunchPosition.position.y,LaunchPosition.position.z), Quaternion.identity);
                    Attack(Bullet,new Vector3(LaunchPosition.position.x-0.055f,LaunchPosition.position.y,LaunchPosition.position.z), Quaternion.identity);
                    break;
                case (int)ArmsLeve.Gun3:
                    Attack(Bullet,LaunchPosition.position,Quaternion.identity);
                    Attack(Bullet,new Vector3(LaunchPosition.position.x+0.11f,LaunchPosition.position.y,LaunchPosition.position.z), Quaternion.identity);
                    Attack(Bullet,new Vector3(LaunchPosition.position.x-0.11f,LaunchPosition.position.y,LaunchPosition.position.z), Quaternion.identity);
                    break;
            }
            _timer = _date.IntervalTime;
        }
    }

    public void PlayerMove()
    {
        //获取鼠标按下时的位置并转为世界坐标
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //获取鼠标位置
            _date.WorldPressPosition = Camera.main.ScreenToWorldPoint(MousePressPosition); //将鼠标位置转为世界坐标
            _date.PlayerPosition = transform.position; //获取玩家位置
        }

        //获取鼠标的实时位置并转为世界坐标
        if (_gameControl.MouseDownStatus)
        {
            _date.MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //获取鼠标在屏幕上的坐标
            _date.WorldPosition = Camera.main.ScreenToWorldPoint(_date.MousePosition); //将屏幕坐标转换为世界坐标
            Vector3 Position;
            Position.x = Mathf.Clamp(_date.PlayerPosition.x + (_date.WorldPosition.x - _date.WorldPressPosition.x), -2,
                2); //计算玩家目标点的X轴坐标
            Position.y = transform.position.y;
            Position.z = transform.position.z;
            transform.position = Position;
        }
    }

    protected override void Attack(GameObject obj,Vector3 position,Quaternion quaternion)
    {
        base.Attack(obj, position, quaternion);
    }
    /// <summary>
    /// 设置武器的等级
    /// </summary>
    /// <param name="leve"></param>
    void SetArms(ArmsLeve leve)
    {
        
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
                _anim = PlayerGunleve3.transform.Find("Gun").GetComponent<Animator>();
                break;
        }
            _anim.SetInteger("Gun", (int) leve);//播放对应枪械等级的动画
            _date.ArmsLeve = (int) leve;
    }
}
