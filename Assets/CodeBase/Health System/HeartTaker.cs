using UnityEngine;

public class HeartTaker : MonoBehaviour
{
    [SerializeField] private Health _health;

    public IRegeneratable Regenerator => _health;
}
