using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected float ActivityTime = 6f;
    [SerializeField] protected float Cooldown = 4f;
    [SerializeField] protected float IntervalInSeconds = 0.5f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioActivated;
    [SerializeField] private AudioClip _audioDeactivated;

    protected WaitForSeconds WaitInterval;

    private Coroutine _coroutine;

    public delegate void TimeHandler(float time, float maxTime);
    public virtual event TimeHandler TimeChanged;

    private void Awake()
    {
        WaitInterval = new WaitForSeconds(IntervalInSeconds);
    }

    public void Activate()
    {
        _coroutine ??= StartCoroutine(Execute());
    }

    public void Cancel()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    protected abstract IEnumerator Use();

    protected void UpdateTime(float time, float maxTime)
    {
        TimeChanged?.Invoke(time, maxTime);
    }

    private IEnumerator Execute()
    {
        _audioSource.PlayOneShot(_audioActivated);
        yield return StartCoroutine(Use());

        _audioSource.PlayOneShot(_audioDeactivated);
        yield return StartCoroutine(Recover());

        _coroutine = null;
    }

    private IEnumerator Recover()
    {
        for (var time = 0f; time < Cooldown; time += IntervalInSeconds)
        {
            UpdateTime(time, Cooldown);
            yield return WaitInterval;
        }

        UpdateTime(Cooldown, Cooldown);
    }
}

