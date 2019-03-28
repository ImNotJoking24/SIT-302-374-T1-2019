using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpHeight; //jumping force of the player
    public float MovementSpeed; //movement speed of the player
    public Transform CameraFace; //drag child object onto here, need it for camera movement
    bool _CanJump = false;
    Rigidbody _Rb;

    private void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        _Rb.angularDrag = 0f;
    }

    private void FixedUpdate()
    {
        PhysicsMovementController();
    }

    private void PhysicsMovementController()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //get A,W keys
        float vertical = Input.GetAxisRaw("Vertical"); //get W, S keys
        float jump = Input.GetAxisRaw("Jump"); //get <Space> key

        //jump mechanics
        if (jump == 1 && _CanJump == true) 
        {
            _Rb.AddForce(new Vector3(0f, JumpHeight, 0f));
            _CanJump = false;
        }

        //movement mechanics
        if (vertical != 0 || horizontal != 0) //update rotation of the character when WASD is pressed
        {
            transform.eulerAngles = new Vector3(0, CameraFace.transform.eulerAngles.y, 0);
        }
        Vector3 movement = new Vector3(horizontal * MovementSpeed * Time.deltaTime, 0, vertical * MovementSpeed * Time.deltaTime); 
        _Rb.transform.Translate(movement); //move the character
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _CanJump = true;
        }
    }
}
