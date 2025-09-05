using UnityEngine;

[RequireComponent(typeof(Alarm))]
[RequireComponent(typeof(AlarmDetector))]
public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private AlarmDetector _alarmDetector;
    [SerializeField] private float _maxVolume = 0.5f;

    private void OnEnable()
    {
        _alarmDetector.AlarmStateChanged += OnAlarmStateChanged;
    }

    private void Awake()
    {
        _alarmDetector = GetComponent<AlarmDetector>();
        _alarm = GetComponent<Alarm>();
        _alarm.SetTargetVolume(0f);
    }

    private void OnDisable()
    {
        _alarmDetector.AlarmStateChanged -= OnAlarmStateChanged;
    }

    private void OnAlarmStateChanged(bool isAlarmActive)
    {
        float targetVolume = isAlarmActive ? _maxVolume : 0f;
        _alarm.SetTargetVolume(targetVolume);
    }
}
