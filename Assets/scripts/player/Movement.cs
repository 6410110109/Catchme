using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkingSpeed = 5f;
    public float runningSpeed = 10f;
    public float mouseSensitivity = 100f;
    public float maxClamp, minClamp;

    private CharacterController controller;
    private Camera playerCamera;
    private float verticalRotation = 0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minClamp, maxClamp);

        transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Determine the speed based on whether the Shift key is held down or not
        float speed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;

        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement;
        controller.Move(movement.normalized * speed * Time.deltaTime);
    }
}
