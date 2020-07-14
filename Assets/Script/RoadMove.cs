using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public float MoveSpeed;
    float _sizeZ=15f;

    private Vector3 _startPosition;
    private float _newPosition;
    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        _newPosition = Mathf.Repeat(Time.time * MoveSpeed, _sizeZ);
        transform.position = _startPosition + Vector3.back * _newPosition;
    }
}
