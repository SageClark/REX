using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Crosshair : MonoBehaviour
{
    Vector3 _mousePosition;
    private float _speed = 1000;

    void Start()
    {
        
    }

    void Update()
    {
        _mousePosition = UtilsClass.GetMouseWorldPosition();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_mousePosition.x, _mousePosition.y, 0), _speed * Time.deltaTime);
    }
}
