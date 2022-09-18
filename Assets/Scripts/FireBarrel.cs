using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrel : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private Collider2D _explosionCollider;
    [SerializeField]
    private Collider2D _collider;
   
    private BigDemon _bigDemonScript;
    private GameObject _bigDemonObject;

    private Vector3 _fireBarrelPos;
    private Vector3 _enemyPos;
    private Vector3 _playerPos;

    private float _distanceFromEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _playerObject = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        _fireBarrelPos = transform.position;
        _playerPos = _playerObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _animator.SetBool("shot", true);
            _explosionCollider.enabled = true;
            _collider.enabled = false;
           /* if (_playerPos.x < transform.position.x + 0.01f || _playerPos.x > transform.position.x - 0.01f && _playerPos.y < transform.position.y + 0.01f || _playerPos.y > transform.position.y - 0.01f)
            {
                Destroy(_playerObject);
            }*/
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _animator.SetBool("shot", true);
            _explosionCollider.enabled = true;
            _collider.enabled = false;
            /* if (_playerPos.x < transform.position.x + 0.01f || _playerPos.x > transform.position.x - 0.01f && _playerPos.y < transform.position.y + 0.01f || _playerPos.y > transform.position.y - 0.01f)
             {
                 Destroy(_playerObject);
             }*/
        }
    }
}
