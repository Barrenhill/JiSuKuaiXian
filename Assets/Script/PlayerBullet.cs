using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{

   
    private void Start()
    {
        moveSpeed = 10f;
    }

    protected override void Attack(GameObject obj,int value)
    {
        base.Attack(obj,value);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            Attack(other.gameObject,HurtValue);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
    }
}
