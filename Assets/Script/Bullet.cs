using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    /// <summary>
    /// 指示是否由玩家发射
    /// </summary>
    public bool IsPlayer;
    private void Start()
    {
        moveSpeed = 10f;
    }

    private void Update()
    {
        base.Move();
    }
}
