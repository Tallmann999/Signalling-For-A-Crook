using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        const string Horizontal = "Horizontal";
        const string Vertical = "Vertical";

        float horizontalInput = Input.GetAxis(Horizontal);
        float verticalInput = Input.GetAxis(Vertical);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            _playerMover.Moving();
        }
        else
        {
            _playerMover.Idle();
        }
    }
}
