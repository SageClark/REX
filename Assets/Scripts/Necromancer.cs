using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    private float _minDistance = 5f;
    private float _distance;
    private float _frequency = 1.0f;
    private float _amplitude = 1.0f;
    private float _timeToFire;

    private int _enemyHealth = 3;

    private bool _hitByPlayer;
    private bool _playerInRange;

    private GameObject _player;
    private Transform _playerTransform;
    private Player _playerScript;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _playerSpriteRenderer;
    private Animator _animator;

    private Vector3 _pos;
    private Vector3 _axis;

    [SerializeField]
    private GameObject _blast;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _animator = GetComponent<Animator>();

        _pos = transform.position;
        _axis = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = _playerTransform.position;
        Vector3 enemyPos = transform.position;

        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        if (_distance < _minDistance)
        {
            _playerInRange = true;
        }

        if (enemyPos.x > playerPos.x)
        {
            _spriteRenderer.flipX = true;
        }
        else if (enemyPos.x < playerPos.x)
        {
            _spriteRenderer.flipX = false;
        }

        if (_enemyHealth < 1)
        {
            _playerScript.AddToEnemiesKilled();
            _animator.SetBool("PlayerInRange", false);
            _animator.SetBool("EnemyIsDead", true);
            Destroy(this.gameObject, 0.6f);
        }
        
        _pos = transform.position;
        _axis = transform.right;
    }

    private void FixedUpdate()
    {
        if (_playerInRange && _timeToFire < Time.time)
        {
            Instantiate(_blast, transform.position, Quaternion.identity);
            _timeToFire = Time.time + 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _enemyHealth--;
            _hitByPlayer = true;
            StartCoroutine(EnemyHitColorChange());
            Destroy(collision.gameObject);
        }

    }

    public IEnumerator EnemyHitColorChange()
    {
        while (_hitByPlayer)
        {
            _spriteRenderer.color = Color.blue;
            yield return new WaitForSeconds(0.05f);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            _hitByPlayer = false;
        }
    }

    private void ZigZag()
    {
        transform.position = _pos + _axis * Mathf.Sin(Time.time * _frequency) * _amplitude;
    }
}
