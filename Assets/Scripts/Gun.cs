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
    }
    
    private Transform _aimTransform;
    private Transform _aimGunEndPointTransform;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _gunEndPointPosition;
    private Vector3 _pubMousePosition;

    private void Awake()
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
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private IEnumerator MuzzleFlash()
    {
        _muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _muzzleFlash.SetActive(false);
    }

    public Vector3 GetMousePos()
    {
        return _pubMousePosition;
    }
}
