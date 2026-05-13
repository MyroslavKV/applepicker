using UnityEngine;

public class AppleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddPoint();

            Destroy(gameObject);
        }
    }
}
