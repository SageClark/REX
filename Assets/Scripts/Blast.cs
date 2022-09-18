using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    private GameObject _player;

    private float _speed = 4;

    private Vector3 _playerPos;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerPos = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerPos, _speed * Time.deltaTime);

        if(transform.position == _playerPos)
        {
            Destroy(this.gameObject);
        }
    }
}
