using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public IDamageable Damageable => _health;
}
