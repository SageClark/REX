using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int gunIDNum = 1;
    public int _enemiesKilled;
    public int _numberOfKeys = 0;

    private float _speed = 3;   
    private float _playerHealth = 10;
    private float _spikeDamageDelay;
    private float _delaySeconds = 0.25f;

    private bool _collidingWithSpike;
    private bool _collidingWithBigDemon;
    private bool _fellInHole = false;
    private bool _foundCandyCannon;

    private Animator _animator;

    [SerializeField]
    private AudioClip _bigDemonDeath;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _baseSprite;
    [SerializeField]
    private Sprite _reverseSprite;
    [SerializeField]
    private AudioSource _audioSourse;
    [SerializeField]
    private SpriteRenderer _firstDoor;
    [SerializeField]
    private Sprite _openDoorSprite;
    [SerializeField]
    private Animator _doorAnimator;
    [SerializeField]
    private Animation _doorAnimation;
    [SerializeField]
    private Collider2D _firstDoorBoxCollider;
    [SerializeField]
    private Gun _gun;
    [SerializeField]
    private Shooting _shooting;
    [SerializeField]
    private Image _healthBar;
    [SerializeField]
    private GameObject _aim;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private TextMeshProUGUI _keyText;
    [SerializeField]
    private GameObject _pistol;
    [SerializeField]
    private GameObject _cannon;

    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _spikeDamageDelay = Time.time;
    }

    // Update is called once per frame
    void Update()
    {                     
        _keyText.text = "x " + _numberOfKeys;
        
        _healthBar.fillAmount = _playerHealth / 10;

        if(gunIDNum == 1)
        {
            _pistol.SetActive(true);
            _cannon.SetActive(false);
        }
        if(gunIDNum == 2 && _foundCandyCannon)
        {
            _pistol.SetActive(false);
            _cannon.SetActive(true);
        }
        
        //_movement.x = Input.GetAxisRaw("Horizontal");
        //_movement.y = Input.GetAxisRaw("Vertical");

        //_animator.SetFloat("Horizontal", _movement.x);
        //_animator.SetFloat("Vertical", _movement.y);
        //_animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (_collidingWithSpike == true && Time.time > _spikeDamageDelay)
        {
            _playerHealth--;
            _spriteRenderer.color = Color.red;
            _spikeDamageDelay = Time.time + _delaySeconds;
        }

        if(_playerHealth < 1 && !_fellInHole)
        {
            Destroy(_gun);
            Destroy(_shooting);
            Destroy(_aim);
            Destroy(_cannon);
            _speed = 0;
            
            if (_fellInHole == false)
            {
                _animator.SetBool("PlayerDied", true);
            }
           
            _audioSourse.clip = _bigDemonDeath;
            _audioSourse.Play();
            _gameManager.GameOver();
            Destroy(this.gameObject,2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _spriteRenderer.sprite = _reverseSprite;
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _spriteRenderer.sprite = _baseSprite;
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _audioSourse.Play();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _spriteRenderer.sprite = _reverseSprite;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _spriteRenderer.sprite = _baseSprite;
        }
    }
    
    public void SetFoundCannonTrue()
    {
        _foundCandyCannon = true;
    }

    public bool CannonHasBeenFound()
    {
        return _foundCandyCannon;
    }
    
    public void AddOneToKeys()
    {
        _numberOfKeys++;
    }

    public void SubtractOneFromKeys()
    {
        _numberOfKeys--;
    }
    
    public void SetCollisionWithSpikeFalse()
    {
        _collidingWithSpike = false;
    }

    public void SetCollisionWithSpikeTrue()
    {
        _collidingWithSpike = true;
    }

    public IEnumerator SpikeDamageOverTime()
    {
        while (_collidingWithSpike)
        {
            _playerHealth--;
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);
            Debug.Log(_playerHealth);
        }
    }
    private IEnumerator BigDemonDamageOverTime()
    {
        while (_collidingWithBigDemon)
        {
            _playerHealth--;
            
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);
            Debug.Log(_playerHealth);
        }
    }

    private IEnumerator PlayerDamageFlash()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BigDemon"))
        {
            _collidingWithBigDemon = true;
            StartCoroutine(BigDemonDamageOverTime());
        }

        if (collision.CompareTag("NecroBlast"))
        {
            _playerHealth -= 2;
            Destroy(collision.gameObject);
            StartCoroutine(PlayerDamageFlash());
        }
        
        if (collision.CompareTag("Explosion"))
        {
            _playerHealth -= 5;
            Destroy(collision.gameObject);
            StartCoroutine(PlayerDamageFlash());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _collidingWithSpike = false;
        _collidingWithBigDemon = false;
    }

    public void DamagePlayerByOne()
    {
        _playerHealth--;
        StartCoroutine(PlayerDamageFlash());
        Debug.Log("Player Damaged");
    }

    public void AddToEnemiesKilled()
    {
        _enemiesKilled++;
    }

    public int GetEnemiesKilled()
    {
        return _enemiesKilled;
    }

    public void SetBigDemonCollisionFalse()
    {
        _collidingWithBigDemon = false;
    }

    public void SetHealthToZero()
    {
        _playerHealth = 0;
    }

    public void SetFellInHoleToTrue()
    {
        _fellInHole = true;
    }

    public void SetSpeedToZero()
    {
        _speed = 0;
    }

    public void DestroyRigidBody()
    {
        Destroy(_rigidbody);
    }

}
