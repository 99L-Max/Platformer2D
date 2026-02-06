using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private SpawnedCoin _prefab;
    [SerializeField] private int _coinsCount = 5;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _launchForce = 5f;
    [SerializeField] private float _spawnRadius = 2f;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    public void Spawn()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _coinsCount; i++)
        {
            yield return _wait;
            var coin = Instantiate(_prefab, transform.position, Quaternion.identity);
            coin.Flip(_spawnRadius, _launchForce);
        }
    }
}
