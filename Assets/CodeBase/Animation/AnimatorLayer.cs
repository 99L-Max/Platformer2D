using System.Collections;
using UnityEngine;

public class AnimatorLayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _showTime = 1f;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_showTime);        
    }

    public void ShowLayer(int layerIndex)
    {
        StartCoroutine(Show(layerIndex));
    }

    private IEnumerator Show(int layerIndex)
    {
        _animator.SetLayerWeight(layerIndex, 1);
        yield return _wait;
        _animator.SetLayerWeight(layerIndex, 0);
    }
}
