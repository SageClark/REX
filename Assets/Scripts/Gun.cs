using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Gun : MonoBehaviour
{
    //public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 cannonEndPointPosition;
    }
    
    private Transform _aimTransform;
    [SerializeField]
    private Transform _cannonTransform;
    private Transform _aimGunEndPointTransform;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _cannonMuzzleFlash;
    [SerializeField]
    private GameObject _gunEndPointPosition;
    [SerializeField]
    private GameObject _cannonEndPointPosition;
    [SerializeField]
    private Player _playerScript;

    private Vector3 _pubMousePosition;

    //-------------

    private Vector2 _lookDirection;
    private float _lookAngle;

    [SerializeField]
    private GameObject _candyCannon;


    private void Start()
    {
        _aimTransform = GameObject.Find("Aim").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();

    }

    private void HandleAiming()
    {
       /* Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (_playerScript.gunIDNum == 1)
        {
            _aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (_playerScript.gunIDNum == 2)
        {
            _cannonTransform.eulerAngles = new Vector3(0, 0, angle);
        }
       */

        _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
        if (_playerScript.gunIDNum == 1)
        {
            _aimTransform.transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle);
        }
        else if (_playerScript.gunIDNum == 2)
        {
            _candyCannon.transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle);
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
            _cannonMuzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            _cannonMuzzleFlash.SetActive(false);
        }
    }

    public Vector3 GetMousePos()
    {
        return _pubMousePosition;
    }
}
