using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCannonPickUp : MonoBehaviour
{
    private float _distance;
    private float _minDistance = 0.5f;

    private bool _playerInRange;

    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Player _playerScript;
    [SerializeField]
    private GunBarSprite _gunBarScript;

    // Start is called before the first frame update
    void Start()
    {
        
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


        if (_playerInRange && Input.GetKeyDown(KeyCode.K))
        {
            _playerScript.gunIDNum = 2;
            _gunBarScript.SetFoundCannonTrue();
            _playerScript.SetFoundCannonTrue();
            Destroy(this.gameObject);
        }
        else if (!_playerInRange)
        {
            transform.position = transform.position;
        }

    }
}
