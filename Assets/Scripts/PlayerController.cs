using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Face; //camera looks on to face object, and the body of the character follows the face object on wasd input
    public float MoveSpeed;
    public float acceleration = 0;
    public float maxVelocity;
    private string _VerticalInputAxis = "Vertical";
    private string _HorizontalInputAxis = "Horizontal";
    private string _JumpInputAxis = "Jump";
    private Rigidbody _Rb; //rigidbody for jumping 
    private bool _CanJump = true;
    

    private void Start()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    /*
    private void Update()
    {
        float vertical = Input.GetAxis(_VerticalInputAxis); //get ws keys
        float horizontal = Input.GetAxis(_HorizontalInputAxis); //get ad keys
        if (vertical != 0 || horizontal != 0) //update rotation only when key clicked
        {
            transform.eulerAngles = new Vector3(0, Face.transform.eulerAngles.y, 0);
        }
        Move(horizontal, vertical);

        //Timer for jump, change this to collision detection with ground (idk how to do that yet)
    }
    */

    private void OnCollisionEnter(Collision collision) //prevent holding jump button for infinite jump
    {
        _CanJump = true;
    }

    private void FixedUpdate()
    {
        //jumping stuff here
        float jump = Input.GetAxis(_JumpInputAxis);
        float vertical = Input.GetAxis(_VerticalInputAxis); //get ws keys
        float horizontal = Input.GetAxis(_HorizontalInputAxis); //get ad keys
        //prevent holding jump button for infinite jumping
        if (jump == 1 && _CanJump == true)
        {
            _CanJump = false;
            _Rb.AddForce(new Vector3(0f, 200f, 0f));
        }
        Move(horizontal, vertical);
    }
    
    //------------------------------------------------------------------//
    //BOTH OTHER MOVE FUNCTIONS CAUSE CLIPPING THROUGH FLOOR

    /*
    private void Move(float horizontal, float vertical)
    {
            _Rb.MovePosition(Face.transform.position + Vector3.right * horizontal * MoveSpeed * Time.deltaTime + Vector3.forward * vertical * MoveSpeed * Time.deltaTime);
    }
    */

    private void Move(float horizontal, float vertical)
    {
        //wasd applying force to character
        _Rb.AddForce(new Vector3(horizontal * MoveSpeed * Time.deltaTime, 0,vertical * MoveSpeed * Time.deltaTime));
    }

    /*
    private void Move(float horizontal, float vertical)
    {
        transform.Translate(Vector3.forward * vertical * MoveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * MoveSpeed * Time.deltaTime);
    }
    */
}
