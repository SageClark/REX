using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
    private float _speed = 100000f;

    private Vector3 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _mousePosition = UtilsClass.GetMouseWorldPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_mousePosition.x, _mousePosition.y, 0) * _speed * Time.deltaTime);
    }
}
