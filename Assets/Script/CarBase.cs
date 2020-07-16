using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MoveObjBase
{
    protected int health;
    protected int maxHealth;
    /// <summary>
    /// 发射子弹的方法
    /// </summary>
    

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="obj">子弹预制体</param>
    /// <param name="quaternion">旋转角度</param>
    /// <param name="isPlayer">是否为玩家发射</param>
    /// <param name="pos">初始位置</param>
    /// <param name="number">要发射的数量</param>
    /// <param name="interval">子弹间的间隔距离</param>
    protected virtual void LaunchBullet(GameObject obj, Quaternion quaternion, Vector3 pos,
        int number, float interval)
    {
        if (obj != null)
        {
            float deviation;
            Vector3 newPos = Vector3.zero;
            if (number % 2 == 1)
            {
                //(奇数偏移算法）偏移量= -(((发射数量-1)*子弹间隔)/2)+原始位置
                deviation = -(((number - 1) * interval) / 2f) + pos.x; //初始偏移
            }
            else
            {
                //（偶数偏移算法）偏移量=-(((发射数量-2)*子弹间隔)/2)+原始位置+子弹间隔/2
                deviation = -((((number - 2) * interval) / 2) + (interval / 2f)) + pos.x;
            }

            for (int i = 0; i < number; ++i)
            {
                newPos.x = deviation + (interval * i);
                newPos.y = pos.y;
                newPos.z = pos.z;
                Instantiate(obj, newPos, quaternion); //生成子弹
            }
        }
    }

    protected virtual void Attack(GameObject obj)
    {
        if (obj.tag.Equals(Tag.Enemy))
        {
            obj.GetComponent<NpcCar>().BeAttack(-maxHealth);
        }
        else
        if(obj.tag.Equals(Tag.Player))
        {
            obj.GetComponent<PlayerCar>().BeAttack(-maxHealth);
        }
    }

    public virtual bool IsDeath()
    {
        Debug.Log(health);
        return health <= 0;
    }
    
    /// <summary>
    /// 被攻击时 改变健康值
    /// </summary>
    /// <param name="value">改变值</param>
    /// <returns>返回是否死亡</returns>
    public virtual void BeAttack(int value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
