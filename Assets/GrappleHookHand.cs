using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookHand : MonoBehaviour
{
    //Grapple Hook ideas
    // * movement (magnet upgrade)
    // * pulling objects (anything from puzzle blocks to pulikng plants out of the ground) can be upgraded to pull heavier things
    // * pushing objects
    // * ball and chain the weight you down
    // * ballon
    // * paraglider
    // * tripwire
    // * shoot around corners OR have some sort of "Reflective" surface that redirects the hook

    public GameObject Hook;
    public LineRenderer Rope;

    bool Firing = false;
    bool isHooked = false;
    bool Returning = false;

    public float HookSpeed = 10;
    public float PullForce = 5;

    private Vector3 hitPos;

    private float currentDistance;

    Camera cam;

    public float HookedDistance;
    bool creatJoint = false;
    SpringJoint joint;
    CharacterController cc;


    private void Start()
    {
        cam =FindObjectOfType<Camera>();
        cc = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3[] linePoints = new Vector3[]
        {
           Rope.transform.position,
            Hook.transform.position
        }; 

        Rope.SetPositions(linePoints);


        if (!Firing && (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Fire]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Fire])))
        {
            Firing = true;

            StartGrappling();

            Hook.transform.parent = null;
        }
        if (Firing && (Input.GetKeyUp(GS.keybinds.Primary[(int)GS.Binds.Fire]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Fire])))
        {
            Firing = false;

            Hook.transform.parent = Rope.transform;
            Hook.transform.rotation = Rope.transform.rotation;
        }

        if (Firing)
        {
            Hook.transform.position = Vector3.MoveTowards(Hook.transform.position, hitPos, HookSpeed * Time.deltaTime);
            currentDistance = Vector3.Distance(Hook.transform.position, hitPos);

            if (isHooked)
            {
                if (creatJoint)
                {
                    creatJoint = false;

                    HookedDistance = Vector3.Distance(hitPos, Rope.transform.position);

                    joint = FindObjectOfType<PlayerMovement>().gameObject.AddComponent<SpringJoint>();
                    joint.autoConfigureConnectedAnchor = false;
                    joint.connectedAnchor = hitPos;

                    joint.spring = 4.5f;
                    joint.damper = 7f;
                    joint.massScale = 4.5f;


                    cc.enabled = false;
                }

                joint.minDistance = HookedDistance * 0.25f;
                joint.maxDistance = HookedDistance * 0.8f;

                if (Input.GetMouseButton(1))
                {
                    HookedDistance -= PullForce * Time.deltaTime;
                }

            }
            

            if (currentDistance <= 0.1f && !isHooked)
            {
                Firing = false;

                Hook.transform.parent = Rope.transform;
                Hook.transform.rotation = Rope.transform.rotation;
            }
        }
        else
        {
            Hook.transform.localPosition = Vector3.MoveTowards(Hook.transform.localPosition, Vector3.zero, HookSpeed * 2 * Time.deltaTime);
            Destroy(joint);
            cc.enabled = true;
        }

        
    }
        

    void StartGrappling()
    {
       

        RaycastHit hit;
        Vector3 point = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(point);

        if (Physics.Raycast(ray, out hit, GS.GrappleDist))
        {
            hitPos = hit.point;

            if (hit.transform.gameObject.layer == 6)
            {
                isHooked = true;
                creatJoint = true;
            }
            else
            {
                isHooked = false;
            }
            
        }
        else
        {
            isHooked = false;
            hitPos = Rope.transform.position + (Rope.transform.forward * GS.GrappleDist);
        }
    }


    //private void Update()
    //{

    //    if (!HasFired && !Returning && (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Fire]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Fire])))
    //    {
    //        HasFired = true;
    //        Hook.transform.parent = null;
    //    }
    //    if (HasFired && (Input.GetKeyUp(GS.keybinds.Primary[(int)GS.Binds.Fire]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Fire])))
    //    {
    //        Returning = true;
    //    }

    //    if (HasFired && !Returning && !isHooked)
    //    {
    //        Hook.transform.Translate(Vector3.forward * HookSpeed * Time.deltaTime);
    //         currentDistance = Vector3.Distance(Hook.transform.position, Rope.transform.position);


    //        if (currentDistance >= MaxDistance)
    //        {
    //            Returning = true;
    //        }
    //    }

    //    if (Returning)
    //    {
    //        isHooked = false;

    //        Hook.transform.parent = Rope.transform;
    //        Hook.transform.rotation = Rope.transform.rotation;

    //        Hook.transform.localPosition = Vector3.MoveTowards(Hook.transform.localPosition, Vector3.zero, HookSpeed * 2 * Time.deltaTime);
    //        currentDistance = Vector3.Distance(Hook.transform.position, Rope.transform.position);

    //        if (currentDistance <= 0.1f)
    //        {
    //            Returning = false;
    //            HasFired = false;

    //        }
    //    }

    //}


    //public void Hooked(Collider col)
    //{
    //    print("hit something");
    //    if (col.gameObject.layer == 6)
    //    {
    //        isHooked = true;
    //    }
    //    else
    //    {
    //        isHooked = false;
    //        Returning = true;
    //    }
    //}
}
