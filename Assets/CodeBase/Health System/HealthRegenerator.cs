using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HealthRegenerator : MonoBehaviour
{
    [SerializeField] private float _regeneratedHealth = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out HeartTaker taker))
        {
            taker.Regenerator.Regenerate(_regeneratedHealth);
            Destroy(gameObject);
        }
    }
}
