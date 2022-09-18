using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private CameraShake _cameraScript;

    private float _bulletForce = 1000f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            CameraShake.Shake(0.05f, 0.05f);

        }
    }

    void Shoot()
    {
        StartCoroutine(MuzzleFlash());
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator MuzzleFlash()
    {
        _muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _muzzleFlash.SetActive(false);
    }
}
