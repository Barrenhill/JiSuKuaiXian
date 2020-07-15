using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MoveObjBase : MonoBehaviour
{
    protected  float moveSpeed;
///<summary>
///移动物体
/// </summary>
    protected virtual void Move()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;//使物体向自身的前方往前或往后移动
    }
    

}
