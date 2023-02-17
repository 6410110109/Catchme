using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    public float walkingSpeed = 5f;
    public float runningSpeed = 10f;
    public float mouseSensitivity = 100f;
    public float maxClamp, minClamp;

    private CharacterController controller;
    private Camera playerCamera;
    private Animator anim;
    private float verticalRotation = 0f;

    private float CurrentVelocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isLocalPlayer)
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

            Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement + transform.up * -1.0f;
            controller.Move(movement.normalized * speed * Time.deltaTime);

            //Animation
            float anim_state = Check_run_or_walk(movement);
            anim.SetFloat("speed", Mathf.SmoothDamp(anim.GetFloat("speed"), anim_state, ref CurrentVelocity, 5.0f * Time.deltaTime));
        }
        
    }

    float Check_run_or_walk(Vector3 movement)
    {
        Vector3 check = new Vector3(movement.x , 0 , movement.z);

        if (check.normalized != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                return 1.0f;
            }
            else
            {
                return 0.5f;
            }
        }
        else
        {
            return 0.0f;
        }
    }
}
