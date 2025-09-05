using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsMove = "IsMove";

    [SerializeField] private Animator _animator;

    public void SetBoolStatus(bool status)
    {
        _animator.SetBool(IsMove, status);
    }
}
