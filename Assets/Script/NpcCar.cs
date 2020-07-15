using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCar : CarBase
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = -2;
    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
    }

}
