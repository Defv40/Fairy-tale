using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls _playerControls;
    [SerializeField] private Vector2 _movementInput;
    public Vector2 MovementInput
    {
        get { return _movementInput; }
        set { _movementInput = value; }
    }
    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.PlayerInteract.Interact.started += ctx => NotificationCenter.Intastance.NotifyObserver(EventType.OnInteract);
    }

    private void Update()
    {
        MovementInput = _playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        _playerControls = null;
    }

    public void EnableMove()
    {
        _playerControls.Enable();
    }
    public void DisableMove()
    {
        _playerControls.Disable();
    }
}
