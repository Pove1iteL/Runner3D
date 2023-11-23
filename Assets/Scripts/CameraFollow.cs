using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playrt;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _playrt.position;
    }

    private void FixedUpdate()
    {
        Vector3 followPosition = new Vector3(transform.position.x,transform.position.y,_offset.z + _playrt.position.z);
        transform.position = followPosition;
    }
}
