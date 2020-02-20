using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysics : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float idleSpeed = 10f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float rayOffSet = 0.5f;
    [SerializeField] float groundCheckDistance = 5f;
    [SerializeField] Vector3 currentVelocity;
    [SerializeField] float rotateSpeed = 2f;
    Rigidbody rb;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }




    void Update()
    {
        //Makes our current velocity visible in the inspector
        currentVelocity = rb.velocity;


        Move();
        Rotate();
        Jump();

    }


    //Get the input axis/buttons
    public float HorizontalAxis()
    {
        float h = Input.GetAxis("Horizontal");
        return h;
    }


    //Get the input axis/buttons
    public float VerticalAxis()
    {
        float v = Input.GetAxis("Vertical");
        return v;
    }
    private void Move()
    {

        //map the input to a direction
        Vector3 movement = new Vector3(0, 0, VerticalAxis()) * speed * Time.deltaTime;
        //find out where our new position is going to be. our current position + our movement
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);
        //Move to our new position
        rb.MovePosition(newPos);
        //update anim
        anim.SetFloat("forwardSpeed", Mathf.Abs(movement.magnitude * speed));
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position + new Vector3(0, rayOffSet, 0), Vector3.down, out hit, groundCheckDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + new Vector3(0, rayOffSet, 0), Vector3.down * groundCheckDistance);
        Gizmos.color = Color.red;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void Rotate()
    {
        //rotate around the Y-Axis using horizontal input and rotation speed
        transform.Rotate(0, HorizontalAxis() * rotateSpeed, 0);
    }
}
