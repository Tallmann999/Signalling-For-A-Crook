using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorToggle : MonoBehaviour
{
    private const string OpeninDoor = "Open";

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _animator.SetTrigger(OpeninDoor);
        }
    }
}
