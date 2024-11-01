using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseSensivity = 150f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }

    void MoveCam()
    {
        if (!PauseMenu.GameIsPause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            // Get user mouse input direction
            float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

            // Prevent player from rotate to far behind
            xRotation -= mouseY; // Make player rotate not in reverse way
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotate the player in specific direction
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
