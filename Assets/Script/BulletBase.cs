using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BulletBase : MoveObjBase
{
    /// <summary>
    /// 伤害量
    /// </summary>
    public int HurtValue;
    protected virtual void Attack(GameObject obj ,int hurt)
    {
        if (obj.tag.Equals(new Tag().Enemy))
        {
            obj.GetComponent<NpcCar>().BeAttack(hurt);
        }
    }

    protected virtual void Move()
    {
        base.Move();
    }
}
