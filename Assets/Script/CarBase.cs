using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MoveObjBase
{
    protected CarBase(){}
    protected CarBase(int health, int attack)
    {
        this.HealthValue = health;
        this.AttackValue = attack;
    }

    [SerializeField] protected int HealthValue { get; set; }
    [SerializeField] protected int AttackValue { get; set; }
    
    protected virtual void Health()
    {
        
    }

    protected virtual void Attack(GameObject obj,Vector3 position,Quaternion quaternion)
    {
        if (obj != null)
        {
            Instantiate(obj, position, quaternion);
        }
        
    }

    protected virtual void BeAttack()
    {
        
    }
    
    protected virtual void Move()
    {
        base.Move();
    }
    
}
