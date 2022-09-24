using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private float _timeToWait;


    private SpriteRenderer _playerRenderer;
    private Player _playerScript;

    void Start()
    {
        _playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foot"))
        {
            if (collision.CompareTag("Foot"))
            {
                _playerScript.SetCollisionWithSpikeTrue();
               // StartCoroutine(_playerScript.SpikeDamageOverTime());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Foot"))
        {
            _playerScript.SetCollisionWithSpikeFalse();
            _playerRenderer.color = Color.white;
        }
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Foot" && Time.deltaTime > _timeToWait)
        {
            _playerScript.DamagePlayerByOne();
            _playerRenderer.color = Color.white;
            _timeToWait = Time.deltaTime + 1f;
        }               
    } */
}
