using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private GameObject _sparkles;
    [SerializeField]
    private GameObject _backLight;
    
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = _playerObject.transform.position;
        Vector3 chestPos = transform.position;

        float distanceFromChest = Vector3.Distance(chestPos, playerPos);
        float minDistanceToOpen = 0.5f;
        
        if(distanceFromChest <= minDistanceToOpen && Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetTrigger("PlayerOpenedChest");
            _sparkles.SetActive(false);
            _backLight.SetActive(false);
        }
    }
}
