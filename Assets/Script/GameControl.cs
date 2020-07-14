using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    /// <summary>
    /// 鼠标状态
    /// </summary>
    public bool MouseDownStatus;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownStatus = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseDownStatus = false;
        }
    }
}
