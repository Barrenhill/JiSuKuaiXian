using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BulletBase : MoveObjBase
{
    public virtual void Attack()
    {
        
    }

    protected virtual void Move()
    {
        base.Move();
    }
}
