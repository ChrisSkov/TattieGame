using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rayOffSet = 0.5f;
    [SerializeField] float groundCheckDistance = 5f; public float speed = 6.0f;
    [SerializeField] float jumpForce = 8.0f;

    [SerializeField] float turnSpeed = 150f;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        if (IsGrounded())
        {


            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position + new Vector3(0, rayOffSet, 0), Vector3.down, out hit, groundCheckDistance);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position + new Vector3(0, rayOffSet, 0), Vector3.down * groundCheckDistance);
    }
}
