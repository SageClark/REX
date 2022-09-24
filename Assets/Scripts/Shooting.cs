using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private Transform _cannonFirePoint;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _cannonMuzzleFlash;
    [SerializeField]
    private Player _playerScript;
    [SerializeField]
    private GameObject _candyBulletPrefab;
    [SerializeField]
    private GameObject _candyCannon;

    private float _bulletForce = 1000f;

    private float _lookAngle;

    private Vector2 _lookDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            CameraShake.Shake(0.05f, 0.05f);
        }

        //-------------------------

       // _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _candyCannon.transform.position;
        //_lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        //_candyCannon.transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);

    }

    void Shoot()
    {
        StartCoroutine(MuzzleFlash());
        if (_playerScript.gunIDNum == 1)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
        }
        else if (_playerScript.gunIDNum == 2)
        {
            GameObject bullet = Instantiate(_candyBulletPrefab, _cannonFirePoint.position, _cannonFirePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = _cannonFirePoint.right * 5;
        }
    }

    private IEnumerator MuzzleFlash()
    {
        if (_playerScript.gunIDNum == 1)
        {
            _muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            _muzzleFlash.SetActive(false);
        }

        if (_playerScript.gunIDNum == 2)
        {
            _muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            _muzzleFlash.SetActive(false);
        }
    }
}
