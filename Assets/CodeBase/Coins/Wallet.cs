using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioSource _audioCoinCollected;

    private int _coinsCount = 0;

    public event Action<int> CoinsCountChanged;

    public void Add(int coinsCount = 1)
    {
        _coinsCount += coinsCount;
        _audioCoinCollected.Play();
        CoinsCountChanged?.Invoke(_coinsCount);
    }
}
