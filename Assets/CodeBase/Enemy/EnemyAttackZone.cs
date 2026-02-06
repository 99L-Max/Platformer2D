using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAttackZone : MonoBehaviour
{
    private readonly List<Player> _players = new();

    public event Action<Player> TargetPlayerChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _players.Add(player);
            TargetPlayerChanged?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _players.Remove(player);

            var targetPlayer = _players.Count() > 0 ? _players.First() : null;

            TargetPlayerChanged?.Invoke(targetPlayer);
        }
    }

    public bool DoesContainPlayers()
    {
        return _players.Count > 0;
    }
}
