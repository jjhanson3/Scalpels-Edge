using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 8f;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.05f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Check for camera lock first
        if (!gameObject.GetComponentInChildren<cameraMovement>().locked)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical"); 

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = gravity;
            }


            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            //Hacky fix to stop the player from falling though the floor on disable
            controller.Move(Vector3.zero);
        }
    }
}