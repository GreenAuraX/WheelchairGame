using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Runtime.InteropServices;
using Unity.Properties;
//using UnityEditor.Experimental.GraphView;
using System.Runtime.CompilerServices;

public class NewPlayerMove : MonoBehaviour
{

    [Header("Player Object Related")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Rigidbody rb;
    [SerializeField] GroundCheck ground;

    [Header("Parameters")]

    [SerializeField] float maxSpeed = .15f;
    [SerializeField] float forwardAcceleration = 2f;
    [SerializeField] float forwardDeceleration = 2f;
    [SerializeField] float reverseSpeed = .6f;
    [SerializeField] float reverseAcceleration = 2f;
    [SerializeField] float ReverseDeceleration = 2f;
    [SerializeField] float rotationSpeed = 120;

    // private Vector3 gravity;
    [SerializeField] float gravityStrength = -9.81f;
    // [SerializeField] float gravityRate = 0.5f;

    // (Experimental) For AllignToGround Script
    // [SerializeField] float slopeForce;

    [SerializeField] Vector3 velocity = new Vector3(0,0,0);

    [Header("Input Bools")]
    private bool isRotatingToLeft;
    private bool isRotatingToRight;
    private bool shiftPressed;

    [Header("Mouse UI Buttons")]
    [SerializeField] GameObject leftMouseUI;
    [SerializeField] GameObject rightMouseUI;
    [SerializeField] GameObject shiftUI;

    RaycastHit slopeHit;

    private void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Player.RotateLeft.performed += ctx => isRotatingToLeft = true;
        playerMovement.Player.RotateLeft.canceled += ctx => isRotatingToLeft = false;

        playerMovement.Player.RotateRight.performed += ctx => isRotatingToRight = true;
        playerMovement.Player.RotateRight.canceled += ctx => isRotatingToRight = false;

        playerMovement.Player.Shift.performed += ctx => shiftPressed = true;
        playerMovement.Player.Shift.canceled += ctx => shiftPressed = false;

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // vCamera = cameraObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transformForward = transform.forward * maxSpeed;
        Vector3 transformBackward = -transform.forward * reverseSpeed;

        if (isRotatingToLeft && rb != null)
        {
            leftMouseUI.SetActive(true);
            float rotationAmount = rotationSpeed * Time.deltaTime;
            rb.transform.Rotate(0, rotationAmount, 0);
        }
        else
        {
            leftMouseUI.SetActive(false);
        }

        if (isRotatingToRight && rb != null)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            rb.transform.Rotate(0, -rotationAmount, 0);
            rightMouseUI.SetActive(true);
        }
        else
        {
            rightMouseUI.SetActive(false);
        }

        if (isRotatingToLeft && isRotatingToRight && ground.isGrounded && !shiftPressed)
        {
            velocity = Vector3.MoveTowards(velocity, transformForward, forwardAcceleration * Time.deltaTime);
            rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        }
        else if (isRotatingToLeft && isRotatingToRight && ground.isGrounded && shiftPressed)
        {
            velocity = Vector3.MoveTowards(velocity, transformBackward, forwardAcceleration * Time.deltaTime);
            rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        }
        else
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, forwardDeceleration * Time.deltaTime);
            rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        }

        if (shiftPressed)
        {
            shiftUI.SetActive(true);
        }
        else
        {
            shiftUI.SetActive(false);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetScene();
        }
    }

    void FixedUpdate()
    {
        // Ground Check
        if (!ground.isGrounded)
        {
            rb.AddForce(Vector3.down * gravityStrength, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Collision with Wall");
        }
    }

    void ResetScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
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

