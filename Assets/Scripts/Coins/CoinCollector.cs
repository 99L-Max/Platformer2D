using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioCoinCollected;

    private int _coinsCount = 0;

    public void Add(int coinsCount = 1)
    {
        _coinsCount += coinsCount;
        _audioCoinCollected.Play();
    }
}
