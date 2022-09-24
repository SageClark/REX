using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour
{
    private int _hitByBUllet;

    [SerializeField]
    private Collider2D _collider;

    [SerializeField]
    private Sprite _brokeWallSprite;

    [SerializeField]
    private Sprite _whiteFlashSprite;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private GameObject _playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitByBUllet >= 3)
        {
            _spriteRenderer.sprite = _brokeWallSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("CandyBullet"))
        {
            _hitByBUllet++;
            StartCoroutine(Flash());
        }

        if (collision.CompareTag("Foot") && _hitByBUllet >= 3)
        {
            _playerObject.transform.position = new Vector3(-65.49f, 16.72f, 0);
        }
    }

    private IEnumerator Flash()
    {
        _spriteRenderer.sprite = _whiteFlashSprite;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.sprite = null;
    }
}
