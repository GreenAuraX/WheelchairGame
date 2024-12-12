using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{

    [Header("Player Object Related")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Rigidbody placePlayerHere;

    [Header("Parameters")]
    [SerializeField] float moveSpeed = 6;
    [SerializeField] float rotationSpeed = 120;
    [SerializeField] float cameraDistance = 5;

    [Header("Checks for Rotation")]
    private bool isRotatingToLeft;
    private bool isRotatingToRight;

    private bool isMovingMouse;

    private bool isScrollingUp;
    private bool isScrollingDown;

    // [Header("Camera")]
    // [SerializeField] CinemachineVirtualCamera vCamera;
    // [SerializeField] GameObject cameraObject;
    

    [Header("Mouse UI Buttons")]
    [SerializeField] GameObject leftMouseUI;
    [SerializeField] GameObject rightMouseUI;


    private void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Player.RotateLeft.performed += ctx => isRotatingToLeft = true;
        playerMovement.Player.RotateLeft.canceled += ctx => isRotatingToLeft = false;

        playerMovement.Player.RotateRight.performed += ctx => isRotatingToRight = true;
        playerMovement.Player.RotateRight.canceled += ctx => isRotatingToRight = false;

        playerMovement.Player.Look.performed += ctx => isMovingMouse = true;
        playerMovement.Player.Look.canceled += ctx => isMovingMouse = false;

        playerMovement.Player.ZoomIn.performed += ctx => isScrollingUp = true;
        playerMovement.Player.ZoomIn.canceled += ctx => isScrollingUp = false;

        playerMovement.Player.ZoomOut.performed += ctx => isScrollingDown = true;
        playerMovement.Player.ZoomOut.canceled += ctx => isScrollingDown = false;



    }


    private void Start()
    {
        placePlayerHere = GetComponent<Rigidbody>();
        // vCamera = cameraObject.GetComponent<Cinemachine.CinemachineVirtualCamera>()
            ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transformForward = transform.forward * moveSpeed * Time.deltaTime;

        if (isRotatingToLeft && placePlayerHere != null)
        {
            leftMouseUI.SetActive(true);
            float rotationAmount = rotationSpeed * Time.deltaTime;
            placePlayerHere.transform.Rotate(0, -rotationAmount, 0);

        }
        else
        {
            leftMouseUI.SetActive(false);
        }

        if (isRotatingToRight && placePlayerHere != null)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            placePlayerHere.transform.Rotate(0, rotationAmount, 0);
            rightMouseUI.SetActive(true);
        }
        else
        {
            rightMouseUI.SetActive(false);
        }

        if (isRotatingToLeft && isRotatingToRight)
        {
            placePlayerHere.MovePosition(placePlayerHere.position + transformForward);
            // placePlayerHere.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            // characterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (isMovingMouse)
        {

        }

        if (isScrollingUp)
        {
            // vCamera.m_CameraDistance = 0;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Collision with Wall");
        }
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

}
