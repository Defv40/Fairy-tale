
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Windows;


public class Player : Actor, IMovable, IObserver
{
    

    private Rigidbody _rb;
    private PlayerInput _input;
    public static Player Instance { get; private set; }
    private PlayerControls _controls;
    private Vector3 _moveDirection;
    [SerializeField] private Animator _animator;
    [SerializeField]private Transform _cameraTarget;
    [SerializeField][Range(0, 50)] private float _playerRotationSpeed; // Скорость поворота в направление движения
    [SerializeField][Range(0, 15)] private float _jumpForce;
    [SerializeField] private Transform _body; // тело которое крутим, иначе ломается камера
    [SerializeField][Range(0, 15)] private float maxDistanceForInteract;
    [SerializeField] private Transform _interactRayObject; // объект из которого будет пускаться луч для взаимодействия
    [SerializeField] private bool _isInteracting;
    private bool _canJump;
    private Ray _interactRay;
    public bool SetMove
    {
        set
        {
            if (value)
            {
                _input.EnableMove();
            }
            else
            {
                _input.DisableMove();
            }
        }
    }
    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.PlayerMovement.Jump.started += ctx => Jump();

        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
       
        _controls.Disable();
        _controls = null;

        NotificationCenter.Intastance.RemoveObserver(this);
    }


    public void OnNotify(EventType type)
    {
        if (type == EventType.OnInteract) TryInteract();
    }

    private void Awake()
    {
        if (Instance != null) Debug.LogError("Больше одного гг на сцене");
        
        Instance = this;

        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
       
    }

    public void Move()
    {
        _moveDirection = _cameraTarget.forward * _input.MovementInput.y + _cameraTarget.right * _input.MovementInput.x;
        _moveDirection.Normalize();
        _moveDirection = _moveDirection * Speed;
        _moveDirection.y = _rb.velocity.y;
        _rb.velocity = _moveDirection;



        PlayAnimation();
    }



    private void PlayAnimation()
    {
        if (_rb.velocity.magnitude > 0.5)
        {
            _animator.SetBool(Animator.StringToHash("isRunnnig"), true);
        }
        else
        {
            _animator.SetBool(Animator.StringToHash("isRunnnig"), false);
        }
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
        
        Debug.DrawRay(_interactRayObject.position, _interactRayObject.forward, Color.red);
    }

    public void TryInteract()
    {
      
        _isInteracting = true;

        _interactRay = new Ray(_interactRayObject.position, _interactRayObject.forward);
        RaycastHit hit;
        if (Physics.Raycast(_interactRay, out hit, maxDistanceForInteract))
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

    public void Jump()
    {
        if (!_canJump) return;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        _animator.SetTrigger("Jump");
        _canJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
        
    }
}

