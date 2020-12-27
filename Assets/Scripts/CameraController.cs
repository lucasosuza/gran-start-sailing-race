using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float acceleration = 50;
    public float accSprintMultiplier = 4;
    
    public float lookSensitivity = 1;
    public float dampingCoefficient = 5;

    public bool focusEnable = true;

    public bool enabled = false;

    Vector3 velocity;

    PlayerMovement playerMovement;

    bool Focused {
        get => Cursor.lockState == CursorLockMode.Locked;
        set {
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = value == false;
        }
    }

    private void OnEnable()
    {
        if (focusEnable) Focused = true;
    }

    void OnDisable() => Focused = false;

    void Start()
    {
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            //enabled = enabled ? false : true;
            playerMovement.enabled = enabled ? false : true;
        }

        if (enabled) {
            if (Focused)
                UpdateInput();
            else if (Input.GetMouseButtonDown(0))
                Focused = true;

            velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);
            transform.position += velocity * Time.deltaTime;
        }
    }

    private void UpdateInput()
    {
        velocity += GetAccelerationVector() * Time.deltaTime;

        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseDelta.x, Space.World);
        transform.Rotate(Vector3.right, mouseDelta.y, Space.Self);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Focused = false;
        }
    }

    private Vector3 GetAccelerationVector()
    {
        Vector3 moveInput = default;

        void AddMovement( KeyCode key, Vector3 dir) {
            if (Input.GetKey(key)) {
                moveInput += dir;
            }
        }

        AddMovement(KeyCode.W, Vector3.forward);
        AddMovement(KeyCode.S, Vector3.back);
        AddMovement(KeyCode.D, Vector3.right);
        AddMovement(KeyCode.A, Vector3.left);
        AddMovement(KeyCode.Space, Vector3.up);
        AddMovement(KeyCode.LeftControl, Vector3.down);

        Vector3 direction = transform.TransformVector(moveInput.normalized);

        if (Input.GetKey(KeyCode.LeftShift)) 
            return direction * (acceleration * accSprintMultiplier);

        return direction * acceleration;
    }
}
