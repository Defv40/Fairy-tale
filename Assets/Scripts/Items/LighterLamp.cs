using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterLamp : InteractableObject
{
    [SerializeField] private GameObject ui_projector;
    private float baseFollowOffset;
    [SerializeField] private Transform lighterBody; // дл€ горизонтального поворота
    [SerializeField] private Transform lamp; // дл€ вертикального наклона
    [SerializeField]
    [Range(0, 10)] private float turnSpeed;
    private bool canControll;
    private float verticalRotation = 0f;
    [SerializeField]public float verticalTurnSpeed;
    public float verticalRotationLimit = 80f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer transporter;

    private void Awake()
    {
        virtualCamera = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
        transporter = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    public override void Interact()
    {
        Player.Instance.SetMove = false;

        canControll = true;

        virtualCamera.LookAt = lighterBody;
        virtualCamera.Follow = lighterBody;

     

        baseFollowOffset = transporter.m_CameraDistance;
        Debug.Log(baseFollowOffset);
        transporter.m_CameraDistance = 18;

        ui_projector.SetActive(true);  
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
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log("here");
        Debug.Log(horizontalInput);
        if (horizontalInput != 0f) // ≈сли нажата клавиша A или D
        {
            float targetRotation = lighterBody.eulerAngles.y + horizontalInput * turnSpeed;
            // ¬ычисл€ем целевой угол поворота

            Quaternion newRotation = Quaternion.Euler(0f, targetRotation, 0f);
            // —оздаем новую кватернионную ротацию

            lighterBody.rotation = Quaternion.Lerp(lighterBody.rotation, newRotation, 0.5f);
            // ѕримен€ем плавный поворот с использованием Lerp
        }

        verticalRotation += verticalInput * verticalTurnSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        // ѕримен€ем вертикальный поворот с лимитом

        lamp.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
