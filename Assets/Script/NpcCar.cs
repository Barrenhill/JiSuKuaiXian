using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : CarBase
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = -2.5f;
        health = maxHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(Tag.Player))
        {
            Attack(other.gameObject);
        }
    }
    public override void BeAttack(int value)
    {
        base.BeAttack(value);
        if (IsDeath())
        {
            Destroy(gameObject);
        }
    }
}
