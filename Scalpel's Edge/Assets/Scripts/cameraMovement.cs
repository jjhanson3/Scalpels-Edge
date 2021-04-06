using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 150f;

    //boolean to allow diabled controls on menu
    public bool locked = false;

    [SerializeField]
    public Transform playerBody;

    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void freeCursor()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        //check for camera lock
        if (!locked)
        {
            //Get Mouse Coordinates
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
