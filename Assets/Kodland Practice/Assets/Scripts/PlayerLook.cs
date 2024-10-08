using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 5f;  
    [SerializeField] private Transform playerBody;        
    [SerializeField] private Transform playerCamera;      

    private float xAxisClamp = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xAxisClamp -= mouseY;
        xAxisClamp = Mathf.Clamp(xAxisClamp, -90f, 45f); 

        playerBody.Rotate(Vector3.up * mouseX);

        playerCamera.localRotation = Quaternion.Euler(xAxisClamp, 0f, 0f);
    }
}
