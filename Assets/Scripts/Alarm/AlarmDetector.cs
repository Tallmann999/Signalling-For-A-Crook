using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover playerMover) == true)
        {
            _alarm.IncreasesSound();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover playerMover) == true)
        {
            _alarm.ReducesSound();
        }
    }
}
