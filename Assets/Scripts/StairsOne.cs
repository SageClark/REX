using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsOne : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject;

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
            _playerObject.transform.position = new Vector3(-38.27f, 7.03f, 0);
        }
    }
}
