using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolum = 0f;
    [SerializeField] private float _maxVolum = 0.5f;
    [SerializeField] private float _fadedSpeed = 1f;

    private float _targetVolume;
    private Coroutine _activeCoroutine = null;

    public void IncreasesSound()
    {
        _targetVolume = _maxVolum;

        if (_activeCoroutine != null)
        {
            StopCoroutine(ChangeVolum());
        }

        _activeCoroutine = StartCoroutine(ChangeVolum());
    }

    public void ReducesSound()
    {
        _targetVolume = _minVolum;

        if (_activeCoroutine != null)
        {
            StopCoroutine(ChangeVolum());
        }

        _activeCoroutine = StartCoroutine(ChangeVolum());
    }

    private IEnumerator ChangeVolum()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadedSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
