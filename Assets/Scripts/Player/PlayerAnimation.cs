using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsMoving = "IsMove";

    [SerializeField] private Animator _animator;

    public void SetBoolStatus(bool status)
    {
        _animator.SetBool(IsMoving, status);
    }
}
