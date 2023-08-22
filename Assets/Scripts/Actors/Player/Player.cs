using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal;

public class Player : Actor, IMovable, IObserver
{
    
    private Rigidbody _rb;
    private PlayerInput _input;

    private Vector3 _moveDirection;

    [SerializeField]private Transform _cameraTarget;
    [SerializeField][Range(0, 50)] private float _playerRotationSpeed; // Скорость поворота в направление движения
    [SerializeField] private Transform _body; // тело которое крутим, иначе ломается камера
    [SerializeField][Range(0, 15)] private float maxDistanceForInteract;
    [SerializeField] private bool _isInteracting;

    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }

    public void OnNotify(EventType type)
    {
        if (type == EventType.OnInteract) TryInteract();
    }

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

        if (targetDirection == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(_body.rotation, targetRotation, _playerRotationSpeed * Time.deltaTime);

        _body.rotation = playerRotation;
    }

    private void Update()
    {
    }

    public void TryInteract()
    {
      
        _isInteracting = true;

        Ray ray = new Ray(_body.transform.position, _body.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistanceForInteract))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }

        _isInteracting = false;
    }
    public void FixedUpdate()
    {
        Move();
        Rotate();
    }
}

