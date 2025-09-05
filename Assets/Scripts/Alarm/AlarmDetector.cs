using System;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    public event Action<bool> AlarmStateChanged;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover playerMover))
        {
            AlarmStateChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover playerMover))
        {
            AlarmStateChanged?.Invoke(false);

        }
    }
}
