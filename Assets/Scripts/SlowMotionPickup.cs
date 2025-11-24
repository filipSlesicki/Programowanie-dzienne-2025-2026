using System.Collections;
using UnityEngine;

public class SlowMotionPickup : MonoBehaviour
{
    [SerializeField] float duration = 3f;
    [SerializeField] float slowScale = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<TimeManager>().SetTimeScale(slowScale, duration);
            Destroy(gameObject);
        }
    }
}
