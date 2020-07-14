using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    private GameControl _gameControl;
    #region 玩家位置控制变量

    /// <summary>
    /// 鼠标按下时的世界坐标
    /// </summary>
    private Vector3 _worldPressPosition;
    /// <summary>
    /// 鼠标实时位置
    /// </summary>
    /// <returns></returns>
    private Vector2 _mousePosition;
    /// <summary>
    /// 鼠标转为世界坐标后的实时位置
    /// </summary>
    private Vector3 _worldPosition;

    /// <summary>
    /// 鼠标按下时的玩家位置
    /// </summary>
    private Vector3 _playerPosition;
    #endregion

    private void Start()
    {
        _gameControl =GameObject.Find("GameControl"). GetComponent<GameControl>();
    }

    private void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        //获取鼠标按下时的位置并转为世界坐标
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePressPosition=new Vector2(Input.mousePosition.x,Input.mousePosition.y);//获取鼠标位置
            _worldPressPosition = Camera.main.ScreenToWorldPoint(MousePressPosition);//将鼠标位置转为世界坐标
            _playerPosition = transform.position;//获取玩家位置
        }
        //获取鼠标的实时位置并转为世界坐标
        if (_gameControl.MouseDownStatus)
        {
            _mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _worldPosition = Camera.main.ScreenToWorldPoint(_mousePosition);//将屏幕坐标转换为世界坐标
            Vector3 Position;
            Position.x = Mathf.Clamp(_playerPosition.x+(_worldPosition.x-_worldPressPosition.x), -2, 2);
            Position.y = transform.position.y;
            Position.z = transform.position.z;
            transform.position = Position;
        }
    }
    
}

