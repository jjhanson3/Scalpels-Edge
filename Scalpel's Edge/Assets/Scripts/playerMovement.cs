using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        //Check for camera lock first
        if (!gameObject.GetComponentInChildren<cameraMovement>().locked)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            //Hacky fix to stop the player from falling though the floor on disable
            controller.Move(Vector3.zero);
        }
    }
}