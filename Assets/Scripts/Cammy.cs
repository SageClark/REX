using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammy : MonoBehaviour
{
    private GameObject _player;
    private Player _playerScript;

    //[SerializeField]
    //private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
        //_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}