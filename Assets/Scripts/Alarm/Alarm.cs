using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 1f;

    private Coroutine _activeFadeCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.Stop();
    }

    public void SetTargetVolume(float targetVolume)
    {
        if (_activeFadeCoroutine != null)
        {
            StopCoroutine(_activeFadeCoroutine);
        }

        _activeFadeCoroutine = StartCoroutine(FadeVolumeCoroutine(targetVolume));
    }

    private IEnumerator FadeVolumeCoroutine(float targetVolume)
    {
        if (targetVolume > 0 && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        while (!Mathf.Approximately(_audioSource.volume, targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume,
                targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (Mathf.Approximately(_audioSource.volume, 0f))
        {
            _audioSource.Stop();
        }

        _activeFadeCoroutine = null;
    }
}
