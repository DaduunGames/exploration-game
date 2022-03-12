using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    //OUTDATED CODE



    //[Header("Movement")]
    ////basic speed variables
    //public float WalkSpeed = 1;
    //public float MaxSpeed = 1;
    //public float SideStepSpeedModifier = 0.75f;
    //public float BackStepSpeedModifier = 0.75f;

    //public float InertiaDampener = 2;

    ////public float MaxSpeed = 2f;

    ////movement logic
    //Vector3 movement;
    //float verticalRotation;
    //bool IsJumping = false;
    ////public bool OnSlope;

    ////variables used to make the player slide down slopes that are too steep
    //public float SlideForce = 5;
    //private RaycastHit hit;
    //private Vector3 slopeParallel;
    //public bool isSliding;
    //private float timePassed;

    //[Header("Jumping")]
    //// variables for jump logic
    //public float Jumpspeed = 0.3f;
    //public float MaxJumpTime = 0.5f;
    //float jumpTime;
    //public float JumpDelay = 0.5f;
    //float jumpDelay;

    ////Hope gravity doesnt need explaining
    //public float Gravity = 10;

    //[Header("Camera")]
    ////min and max allowable cam tilt
    //public float CamMaxTilt = 80;
    //public float CamMinTilt = -90;

    //[Header("Utiliy")]
    ////if we want the player to not be able to control the character
    //public bool DisableInput = false;

    //[Header("References")]
    //public Camera cam;
    //private CharacterController cc;


    

    //void Start()
    //{
    //    movement = Vector3.zero;
    //    cc = GetComponent<CharacterController>();

    //}

    //void Update()
    //{
    //    #region mouse movement
    //    float mouseX = Input.GetAxis("Mouse X") * GS.MouseXSensativity, mouseY = Input.GetAxis("Mouse Y") * GS.MouseYSensativity;

    //    if (!GS.InvertPitch)
    //        mouseY = -mouseY;
    //    verticalRotation += mouseY * GS.MouseYSensativity;

    //    verticalRotation = Mathf.Clamp(verticalRotation, CamMinTilt, CamMaxTilt);

    //    transform.Rotate(0, mouseX * GS.MouseXSensativity, 0);
    //    cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //    }
    //    #endregion


    //    if (!DisableInput)
    //    {
    //        MakecharacterMove();
    //    }
    //}

    //private void MakecharacterMove()
    //{
    //    movement.y -= Gravity;

    //    if (!isSliding) 
    //    {
    //        #region WASD
    //        if (movement.x > 0)
    //        {
    //            movement.x -= WalkSpeed / InertiaDampener;
    //        }
    //        if (movement.z > 0)
    //        {
    //            movement.z -= WalkSpeed / InertiaDampener;
    //        }
    //        if (movement.x < 0)
    //        {
    //            movement.x += WalkSpeed / InertiaDampener;
    //        }
    //        if (movement.z < 0)
    //        {
    //            movement.z += WalkSpeed / InertiaDampener;
    //        }

    //        //Forward
    //        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkForwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkForwards]))
    //        {
    //            movement.z += WalkSpeed;
    //        }

    //        //Backward
    //        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkBackwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkBackwards]))
    //        {
    //            movement.z -= WalkSpeed;

    //        }

    //        //left
    //        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkLeft]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkLeft]))
    //        {
    //            movement.x -= WalkSpeed;

    //        }

    //        //right
    //        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkRight]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkRight]))
    //        {
    //            movement.x += WalkSpeed;

    //        }

    //        movement.x = Mathf.Clamp(movement.x, -MaxSpeed, MaxSpeed);
    //        movement.z = Mathf.Clamp(movement.z, -MaxSpeed, MaxSpeed);
    //        #endregion

    //        #region jumping
    //        if (!IsJumping)
    //        {
    //            if (jumpDelay <= 0 && (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Jump]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Jump])))
    //            {
    //                IsJumping = true;
    //                jumpTime = MaxJumpTime;
    //                jumpDelay = JumpDelay;
    //            }

    //            if (jumpDelay > 0)
    //            {
    //                jumpDelay -= Time.deltaTime;
    //            }
    //        }

    //        if (cc.isGrounded && !(Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Jump]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Jump])))
    //        {
    //            IsJumping = false;
    //            movement.y = -2;
    //        }

    //        if (IsJumping)
    //        {
    //            if (jumpTime > 0)
    //            {
    //                movement.y = Jumpspeed * (jumpTime / MaxJumpTime);
    //                jumpTime -= Time.deltaTime;
    //            }
    //        }
    //        #endregion
    //    }
        
    //    cc.Move(transform.rotation * movement * Time.deltaTime);

    //    SlopeDirection();
    //}

    //private void SlopeDirection()
    //{
    //    //https://forum.unity.com/threads/making-a-player-slide-down-a-slope.469988/

    //    // Raycast with infinite distance to check the slope directly under the player no matter where they are
    //    Physics.Raycast(this.transform.position, Vector3.down, out hit, Mathf.Infinity);

    //    // Saving the normal
    //    Vector3 n = hit.normal;

    //    // Crossing my normal with the player's up vector (if your player rotates I guess you can just use Vector3.up to create a vector parallel to the ground
    //    Vector3 groundParallel = Vector3.Cross(Vector3.up, n);

    //    // Crossing the vector we made before with the initial normal gives us a vector that is parallel to the slope and always pointing down
    //    slopeParallel = Vector3.Cross(groundParallel, n);
    //    //Debug.DrawRay(hit.point, slopeParallel, Color.green);

    //    // Just the current angle we're standing on
    //    float currentSlope = Mathf.Round(Vector3.Angle(hit.normal, transform.up));

    //    if (isSliding)
    //    {
    //        transform.position += (slopeParallel * timePassed) * SlideForce;
           
    //        //Debug.DrawRay(hit.point, (slopeParallel * timePassed) * SlideForce * 10, Color.green);

    //    }

    //    // If the slope is on a slope too steep and the player is Grounded the player is pushed down the slope.
    //    if (currentSlope >= 48f && cc.isGrounded)
    //    {
    //        isSliding = true;
            
    //        timePassed = 1f;
    //    }

        

    //    // If the player is standing on a slope that isn't too steep, is grounded, as is not sliding anymore we start a function to count time
    //    else if (currentSlope < 45 && cc.isGrounded && isSliding)
    //    {
            
    //        timePassed -= Time.deltaTime;
    //        // If enough time has passed the sliding stops. There's no need for these last two if statements, the thing works already, but it's nicer to have the player slide for a little bit more once they get back on the ground
    //        if (timePassed >= 0f)
    //        {
    //            isSliding = false;
    //        }
    //    }

        
    //}

}
