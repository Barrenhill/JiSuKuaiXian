using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameControl Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 鼠标状态
    /// </summary>
    public bool MouseDownStatus;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownStatus = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseDownStatus = false;
        }
    }
}
public struct PlayerDate
{

    /// <summary>
    /// 鼠标按下时的世界坐标
    /// </summary>
    public Vector3 WorldPressPosition;
    /// <summary>
    /// 鼠标实时位置
    /// </summary>
    /// <returns></returns>
    public Vector2 MousePosition;
    /// <summary>
    /// 鼠标转为世界坐标后的实时位置
    /// </summary>
    public Vector3 WorldPosition;
    /// <summary>
    /// 鼠标按下时的玩家位置
    /// </summary>
    public Vector3 PlayerPosition;

    /// <summary>
    /// 发射子弹的间隔时间
    /// </summary>
    public float IntervalTime;
    /// <summary>
    /// 玩家武器等级
    /// </summary>
    public int ArmsLeve;
}

/// <summary>
/// 玩家武器等级
/// </summary>
public enum ArmsLeve
{
    Gun1,
    Gun2,
    Gun3
}
