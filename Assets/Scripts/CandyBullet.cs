
using UnityEngine;

public class CandyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _gasCloud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigDemon") || collision.CompareTag("Necroman"))
        {
            Instantiate(_gasCloud, collision.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            Instantiate(_gasCloud, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
