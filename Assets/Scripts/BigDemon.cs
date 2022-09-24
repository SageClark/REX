using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDemon : MonoBehaviour
{
    private float _speed = 2f;
    private float _minDistance = 3f;
    private float _distance;
    private float _bulletForce = 20000;
    private float _timeToWait;

    private int _enemyHealth = 5;

    private bool _hitByPlayer;
    private bool _playerInRange;
    private bool _collidingWithGas;
    private bool _addedOneToDead;

    private GameObject _player;
    private Transform _playerTransform;
    private Player _playerScript;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _playerSpriteRenderer;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField]
    private Collider2D _boxCollider;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _firePoint;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _timeToWait = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = _playerTransform.position;
        Vector3 enemyPos = transform.position;

        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        if (_distance < _minDistance || _hitByPlayer)
        {
            _playerInRange = true;
        }

        
        if (_playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
            _animator.SetBool("PlayerInRange", true);
        }
        else if (!_playerInRange)
        {
            transform.position = transform.position;
            _animator.SetBool("PlayerInRange", false);
        }

        if (enemyPos.x > playerPos.x)
        {
            _spriteRenderer.flipX = true;
        }
        else if (enemyPos.x < playerPos.x)
        {
            _spriteRenderer.flipX = false;
        }

        if (_enemyHealth < 1 && !_addedOneToDead)
        {
            _audioSource.Play();
            _playerScript.SetBigDemonCollisionFalse();
            _playerScript.AddToEnemiesKilled();
            _addedOneToDead = true;
            _speed = 0;
            _animator.SetTrigger("EnemyIsDead");
            Destroy(_rb);
            Destroy(_boxCollider);
            Destroy(this.gameObject, 2f); // was 0.6f
        }

        if (_collidingWithGas && Time.time > _timeToWait)
        {
            _enemyHealth--;
            _timeToWait = Time.time + 0.2f;
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
            StartCoroutine(KnockBackRoutine());
        }
        
        if (collision.CompareTag("CandyBullet"))
        {
            _enemyHealth--;
            _hitByPlayer = true;
            StartCoroutine(EnemyHitColorChange());
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("GasCloud"))
        {
            _collidingWithGas = true;
        }

        if (collision.CompareTag("Explosion"))
        {
            _enemyHealth -= 5;
            StartCoroutine(EnemyHitColorChange());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GasCloud"))
        {
            _collidingWithGas = false;
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

    private IEnumerator KnockBackRoutine()
    {
        _rb.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.05f);
        _rb.Sleep();
        yield return new WaitForSeconds(0.05f);
        _rb.IsAwake();
    }

    public void KillEnemy()
    {
        _enemyHealth -= 3;
    }
}
