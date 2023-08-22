using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Actor, IMovable
{
    
    private Rigidbody _rb;
    private PlayerInput _input;

    private Vector3 _moveDirection;
    [SerializeField]private Transform _cameraTarget;
    [SerializeField][Range(0, 50)] private float _playerRotationSpeed;
    [SerializeField] private Transform _body;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    public void Move()
    {
        _moveDirection = _cameraTarget.forward * _input.MovementInput.y + _cameraTarget.right * _input.MovementInput.x;
        _moveDirection.Normalize();
        _moveDirection.y = 0;
        _moveDirection = _moveDirection * Speed;
        _rb.velocity = _moveDirection;
        
    }

    public void Rotate()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = _cameraTarget.forward * _input.MovementInput.y + _cameraTarget.right * _input.MovementInput.x;
        targetDirection.Normalize();
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(_body.rotation, targetRotation, _playerRotationSpeed * Time.deltaTime);

        _body.rotation = playerRotation;
    }

    public void FixedUpdate()
    {
        Move();
        Rotate();
    }
}

