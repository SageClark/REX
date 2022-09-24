using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrel : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("CandyBullet"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}
