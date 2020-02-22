using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = 20f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float rotateSpeed = 10f;
    CharacterController characterController;
    Animator anim;


    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

//        SimpleMovement();
   Move();

    }
    void SimpleMovement()
    {
        // Rotate around y - axis
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotateSpeed, 0);
        print(characterController.isGrounded);
        // Move forward / backward
        if (characterController.isGrounded)
        {
            float v = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0.0f, v);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            anim.SetFloat("forwardSpeed", Mathf.Abs(h + v * speed));
            float curSpeed = speed * v;
            characterController.SimpleMove(forward * curSpeed);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

    }
    void Move()
    {
        print(characterController.isGrounded);

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
         //   Vector3 moveDirection = transform.TransformDirection(Vector3.forward);
            transform.Rotate(0, h, 0);

            moveDirection = new Vector3(0, 0.0f, v);
            moveDirection *= speed;
            anim.SetFloat("forwardSpeed", Mathf.Abs(h + v * speed));

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(transform.TransformDirection(moveDirection) * Time.deltaTime);

    }


}

