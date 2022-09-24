using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyColliderRoutine());
        StartCoroutine(DestroyExplosionRoutine());
        CameraShake.Shake(0.1f, 2f);
    }
    
    private IEnumerator DestroyExplosionRoutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private IEnumerator DestroyColliderRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(_collider);
    }
}
