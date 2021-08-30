using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Player player;
    public Vector3 moveInput;

    public PlayerInput playerInput;


    public float moveSpeed;

    public Vector3 rollInput;
    public float rollSpeed;

    public float gravityValue = 9.81f; //make it either 29.81 or 39.81
    
    public float sleepTreshold;
    public float maxAngularVelocity = 40;

    public const float groundRayLength = 1f;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        if (playerInput.is2D)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics.gravity = new Vector3(0, -gravityValue, 0);
        rb.sleepThreshold = sleepTreshold;
        rb.maxAngularVelocity = maxAngularVelocity;
        if (player.alive)
        {
            Move();
        }
        


        if(Physics.Raycast(transform.position, -Vector3.up, groundRayLength))
        {
            grounded = true;
            rollSpeed = 15f;
            moveSpeed = 0;
        } else
        {
            grounded = false;
            rollSpeed = 0.5f;
            moveSpeed = 10;
        }

        
    }

    private void Move()
    {
        Vector3 movement = playerInput.moveInput * moveSpeed;
        rb.AddForce(movement);

        //rb.AddTorque(movement);


        Vector3 rolling = playerInput.rollInput * rollSpeed;
        rb.AddTorque(rolling);


    }

    /*public void OnMoveInput(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
        moveInput = new Vector3(inputValue.x, 0, inputValue.y);

        //moveInput = new Vector3(inputValue.y, 0, -inputValue.x);


        rollInput = new Vector3(inputValue.y, 0, -inputValue.x);
    }*/
}
