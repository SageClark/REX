using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private float _speed = 0.3f;
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private GameObject _keyFoundText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (_transform.position.y < 130f)
        {
            _transform.transform.Translate(Vector3.up * Time.deltaTime * _speed);
        }
    }

    private IEnumerator CountDown()
    {
        _keyFoundText.SetActive(true);
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        _keyFoundText.SetActive(false);
    }
}
