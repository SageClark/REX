using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private Animator _playerAnimator;
    [SerializeField]
    private Player _playerScript;
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private GameObject _aim;
    [SerializeField]
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerScript.DestroyRigidBody();
            _playerScript.SetFellInHoleToTrue();
            _playerScript.SetHealthToZero();
            _playerScript.SetSpeedToZero();
            Destroy(_aim);
            _playerObject.transform.position = transform.position;
            _playerAnimator.SetBool("PlayerFell", true);
            Destroy(_playerObject, 1);
            _gameManager.GameOver();
        }
    }
}
