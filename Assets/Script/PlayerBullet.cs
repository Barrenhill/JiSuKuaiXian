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


    private void OnTriggerEnter(Collider other)
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
