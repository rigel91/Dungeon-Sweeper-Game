using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sprintSpeed;

    Vector3 velocity;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks for grounded, and makes sure that velocity.y is always -2 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //move player
        Vector3 move = transform.right * x + transform.forward * z;
        if (move.magnitude > 1)
        {//get rid of moveing faster when moving diagonally
            move = move/move.magnitude;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {//sprint
            controller.Move(move * speed * Time.deltaTime * sprintSpeed);
        }
        else
        {//walk
            controller.Move(move * speed * Time.deltaTime);
        }
        

        //move player downward by gravity
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //private void OnDrawGizmos()
    //{//draw the physics sphere
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(groundCheck.position, 0.4f);
    //}
}
