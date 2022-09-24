using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyCloudRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyCloudRoutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

}
