using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunBarSprite : MonoBehaviour
{
    private bool _foundCannon;
    private bool _pistolSelected;
    private bool _cannonSelected;
    private bool _initialCannonSetActive;

    [SerializeField]
    private Image _gunBar;
    [SerializeField]
    private Sprite _gunBarSprite1;
    [SerializeField]
    private Sprite _gunBarSprite2;
    [SerializeField]
    private Image _pistolIconImage;
    [SerializeField]
    private Image _cannonImageIcon;

    [SerializeField]
    private Player _playerScript;
    
    void Start()
    {
        if(_playerScript.gunIDNum == 1)
        {
            _gunBar.sprite = _gunBarSprite1;
            _playerScript.gunIDNum = 1;
            _pistolIconImage.transform.localScale = new Vector3(_pistolIconImage.transform.localScale.x + 0.10f, _pistolIconImage.transform.localScale.y + 0.10f, _pistolIconImage.transform.localScale.z);
            _pistolSelected = true;
            _cannonSelected = false;
        }
    }

    void Update()
    {
        _foundCannon = _playerScript.CannonHasBeenFound();

        if(_foundCannon)
        {
            _cannonImageIcon.color = Color.white;
        }

        if(_foundCannon && !_initialCannonSetActive)
        {
            _gunBar.sprite = _gunBarSprite2;
            _playerScript.gunIDNum = 2;
            _cannonImageIcon.transform.localScale = new Vector3(_cannonImageIcon.transform.localScale.x + 0.10f, _cannonImageIcon.transform.localScale.y + 0.10f, _cannonImageIcon.transform.localScale.z);
            _pistolIconImage.transform.localScale = new Vector3(_pistolIconImage.transform.localScale.x - 0.10f, _pistolIconImage.transform.localScale.y - 0.10f, _pistolIconImage.transform.localScale.z);
            _pistolSelected = false;
            _cannonSelected = true;
            _initialCannonSetActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !_pistolSelected)
        {
            _gunBar.sprite = _gunBarSprite1;
            _playerScript.gunIDNum = 1;
            _pistolIconImage.transform.localScale = new Vector3(_pistolIconImage.transform.localScale.x + 0.10f, _pistolIconImage.transform.localScale.y + 0.10f, _pistolIconImage.transform.localScale.z);
            _cannonImageIcon.transform.localScale = new Vector3(_cannonImageIcon.transform.localScale.x - 0.10f, _cannonImageIcon.transform.localScale.y - 0.10f, _cannonImageIcon.transform.localScale.z);
            _pistolSelected = true;
            _cannonSelected = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !_cannonSelected && _foundCannon)
        {
            _gunBar.sprite = _gunBarSprite2;
            _playerScript.gunIDNum = 2;
            _cannonImageIcon.transform.localScale = new Vector3(_cannonImageIcon.transform.localScale.x + 0.10f, _cannonImageIcon.transform.localScale.y + 0.10f, _cannonImageIcon.transform.localScale.z);
            _pistolIconImage.transform.localScale = new Vector3(_pistolIconImage.transform.localScale.x - 0.10f, _pistolIconImage.transform.localScale.y - 0.10f, _pistolIconImage.transform.localScale.z);
            _pistolSelected = false;
            _cannonSelected = true;
        }       
    }

    public void SetFoundCannonTrue()
    {
        _foundCannon = true;
    }
}
