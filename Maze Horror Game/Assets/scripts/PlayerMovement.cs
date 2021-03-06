using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{



    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSprinting = false;
    bool canChange = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left shift") && speed <= 210 && canChange)
        {
            Debug.Log("shift down");
            if (!isSprinting)
            {
                speed += 200f;
            }
            else if (isSprinting)
            {
                speed -= 200;
            }
            canChange = false;
            isSprinting = !isSprinting;

        }
        if (Input.GetKeyUp("left shift"))
        {
            canChange = true;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("sjfhjsd");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey("c"))
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
      



    }
}

