using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public float range_vision = 20.0f;

    private Camera playerCamera;


    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position , playerCamera.transform.forward , out hit , range_vision))
        {
            Debug.DrawLine(playerCamera.transform.position , hit.point);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hit.transform.CompareTag("door"))
                {
                    hit.transform.GetComponentInParent<door_system>().ToggleDoor(hit.transform.position.z < transform.position.z);
                }
            }
        }
    }
}
