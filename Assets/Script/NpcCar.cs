using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : CarBase
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = -2;
        health = maxHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(new Tag().Player))
        {
            Attack(other.gameObject);
        }
    }

    protected override void Attack(GameObject obj)
    {
        base.Attack(obj);
    }

    public override bool? BeAttack(int value)
    {
        if (base.BeAttack(value)==true)
        {
            Destroy(gameObject);
        }
        return null;
    }
}
