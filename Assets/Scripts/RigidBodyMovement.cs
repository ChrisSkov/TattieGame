using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rayOffSet = 0.5f;
    [SerializeField] float groundCheckDistance = 5f;
    [SerializeField] float speed = 6.0f;
    [SerializeField] float jumpForce = 8.0f;
    [SerializeField] float slamForce = 8.0f;

    private Vector3 moveDirection = Vector3.zero;

    bool hasSlammed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        Move();
        Slam();
    }

    private void Move()
    {

        if (IsGrounded())
        {

            hasSlammed = false;
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

    void Slam()
    {
        if (!IsGrounded() && !hasSlammed && Input.GetButton("Jump") && Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
            hasSlammed = true;
        }
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
