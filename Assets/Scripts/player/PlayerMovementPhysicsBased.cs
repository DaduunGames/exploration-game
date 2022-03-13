using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhysicsBased : MonoBehaviour
{
    [Header("Movement")]
    //basic speed variables
    public float acceleration  = 3500f; //dont judge me
    Vector3 movement;
    public float InertiaDampener = 10;
    bool isMoving;

    public float WalkSpeed = 10f;
    public float RunSpeed = 15f;
    public float AirSpeed = 15f;

    bool IsRunning = false;

    [Header("Jumping")]
    // variables for jump logic
    public float JumpForce = 40000f;
    



    [Header("Camera")]
    //min and max allowable cam tilt
    public float CamMaxTilt = 80;
    public float CamMinTilt = -90;
    float verticalRotation;

    [Header("Utiliy")]
    //if we want the player to not be able to control the character
    public bool DisableMovement = false;
    public bool DisableCameraMovement = false;
    public bool IsHooked = false;

    [Header("References")]
    private Camera cam;
    private Rigidbody rb;
    public GroundDetector gd;




    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region mouse movement
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (!DisableCameraMovement)
        {
            float mouseX = Input.GetAxis("Mouse X") * GS.MouseXSensativity, mouseY = Input.GetAxis("Mouse Y") * GS.MouseYSensativity;

            if (!GS.InvertPitch)
                mouseY = -mouseY;
            verticalRotation += mouseY * GS.MouseYSensativity;

            verticalRotation = Mathf.Clamp(verticalRotation, CamMinTilt, CamMaxTilt);

            transform.Rotate(0, mouseX * GS.MouseXSensativity, 0);
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
        #endregion


        if (!DisableMovement)
        {
            MakecharacterMove();
        }
    }

    private void MakecharacterMove()
    {
        movement = Vector3.zero;
        isMoving = false;

        if (gd.IsGrounded)
        {
            //Forward
            if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkForwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkForwards]))
            {
                movement.z += 1;
                isMoving = true;
            }

            //Backward
            if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkBackwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkBackwards]))
            {
                movement.z -= 1;
                isMoving = true;
            }

            //left
            if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkLeft]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkLeft]))
            {
                movement.x -= 1;
                isMoving = true;
            }

            //right
            if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkRight]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkRight]))
            {
                movement.x += 1;
                isMoving = true;
            }

            if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Run]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Run]))
            {
                IsRunning = true;
            }
            else
            {
                IsRunning = false;
            }

        }

        movement.Normalize();
        movement *= acceleration  * Time.deltaTime;
        movement = cam.transform.rotation * movement;
        movement.y = 0;


        if ( gd.IsGrounded && (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Jump]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Jump])))
        {
            movement.y = JumpForce * Time.deltaTime;
            isMoving = true;
        }



        if (isMoving)
        {
            rb.AddForce(movement);
        }



        if (gd.IsGrounded) 
        {
            if (!isMoving)
            {
                rb.velocity = new Vector3(rb.velocity.x / InertiaDampener, rb.velocity.y, rb.velocity.z / InertiaDampener);
            }

            if (IsRunning)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, RunSpeed);
            }
            else
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, WalkSpeed);
            }
            
        }
        else
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, AirSpeed);
        }

    }
}
