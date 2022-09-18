using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Collider2D _firstDoorBoxCollider;
    private int _enemiesKilled;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _enemiesKilled = _player.GetEnemiesKilled();

        if (_enemiesKilled == 1)
        {
            _animator.SetBool("DoorOpening", true);
            _firstDoorBoxCollider.enabled = false;
        }
    }
}
