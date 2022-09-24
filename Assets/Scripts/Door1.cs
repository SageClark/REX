using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    private float minDistanceToOpen = 0.1f;

    private int _enemiesKilled;

    private bool _keyCoroutineStarted;

    [SerializeField]
    private int _doorID;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject _playerObject;

    [SerializeField]
    private Animator _firstAnimator;
    [SerializeField]
    private Animator _secondAnimator;
    [SerializeField]
    private Animator _thirdAnimator;

    [SerializeField]
    private Collider2D _firstDoorBoxCollider;
    [SerializeField]
    private Collider2D _secondDoorBoxCollider;
    [SerializeField]
    private Collider2D _thirdDoorBoxCollider;

    [SerializeField]
    private GameObject _keyUsedText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemiesKilled = _player.GetEnemiesKilled();

        Vector3 playerPos = _playerObject.transform.position;
        Vector3 doorPos = transform.position;

        float distanceFromChest = Vector3.Distance(doorPos, playerPos);

        if (_doorID == 1 && _player._enemiesKilled >= 1)
        {
            _firstAnimator.SetBool("DoorOpening", true);
            _firstDoorBoxCollider.enabled = false;
        }

        else if (_doorID == 2 && _player._enemiesKilled >= 12)
        {
            _secondAnimator.SetBool("DoorOpening", true);
            _secondDoorBoxCollider.enabled = false;
        }

        else if (_doorID == 3 && _player._enemiesKilled >= 20 && _player._numberOfKeys > 0 && !_keyCoroutineStarted && distanceFromChest <= minDistanceToOpen && Input.GetKeyDown(KeyCode.K))
        {
            _player._numberOfKeys--;
            _thirdAnimator.SetBool("DoorOpening", true);
            _thirdDoorBoxCollider.enabled = false;
            StartCoroutine(UsedKeyRoutine());
            _keyCoroutineStarted = true;
        }
    }

    private IEnumerator UsedKeyRoutine()
    {
        _keyUsedText.SetActive(true);
        yield return new WaitForSeconds(2f);
        _keyUsedText.SetActive(false);
    }
}
