using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void Idle()
    {
        _playerAnimation.SetBoolStatus(false);
    }

    public void Moving()
    {
        _playerAnimation.SetBoolStatus(true);
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distanse = direction * _moveSpeed * Time.deltaTime;
        transform.Translate(distanse * Vector3.forward);
    }
}
