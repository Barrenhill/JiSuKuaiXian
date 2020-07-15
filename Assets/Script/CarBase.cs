using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MoveObjBase
{
    protected int health;
    protected int maxHealth;
    protected virtual void Start()
    {
        
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="obj">子弹预制体</param>
    /// <param name="position">生成位置</param>
    /// <param name="quaternion">旋转角度</param>
    /// <param name="isPlayer">是否为玩家发射</param>
    protected virtual void LaunchBullet(GameObject obj,Vector3 position,Quaternion quaternion)
    {
        if (obj != null)
        {
            Instantiate(obj, position, quaternion);//生成子弹
            
        }
    }

    protected virtual void Attack(GameObject obj)
    {
        if (obj.tag.Equals(new Tag().Enemy))
        {
            obj.GetComponent<NpcCar>().BeAttack(-20);
        }
        else
        if(obj.tag.Equals(new Tag().Player))
        {
            obj.GetComponent<PlayerCar>().BeAttack(-20);
        }
    }

    public virtual bool IsDeath()
    {
        return health <= 0;
    }
    
    /// <summary>
    /// 被攻击时 改变健康值
    /// </summary>
    /// <param name="value">改变值</param>
    /// <returns>返回是否死亡</returns>
    public virtual bool? BeAttack(int value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
        return health == 0 ? true : false;

    }
    
    protected virtual void Move()
    {
        base.Move();
    }
    
}
