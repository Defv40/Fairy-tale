using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterLamp : InteractableObject, IObserver
{
    [SerializeField] private GameObject ui_projector;
    private float baseFollowOffset;
    [SerializeField] private Transform lighterBody; // для горизонтального поворота
    [SerializeField] private Transform lamp; // для вертикального наклона
    [SerializeField]
    [Range(0, 10)] private float turnSpeed;
    private bool canControll;
    private float verticalRotation = 0f;
    [SerializeField]public float verticalTurnSpeed;
    public float verticalRotationLimit = 80f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer transporter;
    private Material _currentLampMaterial;
    [SerializeField] private Light lampLight;

    private bool _canInteractWithWindow = false;
    private WindowManager windowManager;
    // для мини игры
    [SerializeField] private AudioClip[] _audioClips;

    [SerializeField] private int _currentWindowIndex; // текущий индекс окна который мы должны Unfill
    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }
    private void Awake()
    {
        virtualCamera = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
        transporter = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        windowManager = GameObject.FindFirstObjectByType<WindowManager>();
    }
    public override void Interact()
    {
        if (windowManager.Key == null) return;

        Player.Instance.SetMove = false;

        canControll = true;

        virtualCamera.LookAt = transform;
        virtualCamera.Follow = transform;

     

        baseFollowOffset = transporter.m_CameraDistance;
       
        transporter.m_CameraDistance = 18;

        ui_projector.SetActive(true);

        //if (!_canInteractWithWindow)
            NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractLamper);
    }

    private void Update()
    {
        if (canControll)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            virtualCamera.LookAt = Player.Instance.transform;
            virtualCamera.Follow = Player.Instance.transform;

            canControll = false;



            Player.Instance.SetMove = true;

            transporter.m_CameraDistance = baseFollowOffset;
            ui_projector.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.H) && _canInteractWithWindow)
        {
            TryInteractWithWindow();
        }

        DebugLine();
    }
    private void TryInteractWithWindow()
    {
        Ray ray = new Ray(lampLight.transform.position, lampLight.transform.forward);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit, 100f, ~LayerMask.NameToLayer("WindowMiniGame")))
        {
            
            if (hit.collider.gameObject.TryGetComponent<MiniGameWindow>(out MiniGameWindow window))
            {
                bool rightWindow = window.Compare(_currentWindowIndex, _currentLampMaterial);
                if (rightWindow)
                {
                    Debug.Log("правильное окно");
                    _currentWindowIndex++;
                    if (_currentWindowIndex > 3)
                    {
                        _currentWindowIndex = 0;
                        SoundSystem.Instance.PlaySound(_audioClips[1], .3f);
                        windowManager.NextLevel();
                        return;
                    }

                    SoundSystem.Instance.PlaySound(_audioClips[0], 1f);
                }
                else
                {
                    Debug.Log("Не то окно");
                    _currentWindowIndex = 0;
                    windowManager.ResetProgress();
                }
            }
        }
    }

    private void DebugLine()
    {
        Debug.DrawRay(lampLight.transform.position, lampLight.transform.forward * 100f, Color.red);
    }
    
    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
      
        
        if (horizontalInput != 0f) // Если нажата клавиша A или D
        {
            float targetRotation = lighterBody.eulerAngles.y + horizontalInput * turnSpeed;
            // Вычисляем целевой угол поворота

            Quaternion newRotation = Quaternion.Euler(0f, targetRotation, 0f);
            // Создаем новую кватернионную ротацию

            lighterBody.rotation = Quaternion.Lerp(lighterBody.rotation, newRotation, 0.5f);
            // Применяем плавный поворот с использованием Lerp
        }

        verticalRotation -= verticalInput * verticalTurnSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        // Применяем вертикальный поворот с лимитом

        lamp.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    public void SetMaterial(Material material)
    {
        _currentLampMaterial = material;

        Debug.Log(_currentLampMaterial.name);

        ChangeLampColor();
    }

    private void ChangeLampColor()
    {
        Color lampColor = Color.white;

        switch (_currentLampMaterial.name)
        {
            case "Red":
                lampColor = Color.red;
                break;
            case "Green":
                lampColor = Color.green;
                break;
            case "Blue":
                lampColor = Color.blue;
                break;
        }

        lampLight.color = lampColor;
    }

    public void OnNotify(EventType type)
    {
        if (EventType.OnEndFillWindows == type)
        {
            _canInteractWithWindow = true;
        }

        if (EventType.OnStartFillWindows == type)
        {
            _canInteractWithWindow = false;
        }
    }
}
