using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWallReturn : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerObject.transform.position = new Vector3(-37.50862f, 13.22775f, 0);
        }
    }
}
