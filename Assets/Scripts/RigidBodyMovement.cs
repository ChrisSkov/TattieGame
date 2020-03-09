using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    [Header("Player variables")]
    [SerializeField] float speed = 6.0f;
    [SerializeField] float jumpForce = 8.0f;
    [SerializeField] float slamForce = 8.0f;
    [Header("Game feel")]
    [SerializeField] float rayOffSet = 0.5f;
    [Tooltip("How close to the ground do we have to be to jump")]
    [SerializeField] float groundCheckDistance = 5f;

    Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;
    Animator anim;
    bool hasSlammed = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        Move();
        Slam();
    }

    public void Move()
    {

        if (IsGrounded())
        {
            hasSlammed = false;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (moveDirection.magnitude > 1)
            {
                moveDirection = moveDirection.normalized;
            }
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
            anim.SetFloat("forwardSpeed", Input.GetAxis("Vertical"));
            anim.SetFloat("horizontalSpeed", Input.GetAxis("Horizontal"));
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {

            anim.SetBool("isRunning", false);
        }


        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }

    public void Slam()
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
