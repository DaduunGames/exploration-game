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
    bool Hooking = false;
    bool IsHooked = false;
    

    public float HookSpeed = 10;
    public float PullForce = 5;

    RaycastHit hit;
    private Vector3 hitPos;

    private float currentDistance;

    Camera cam;
    PlayerMovementPhysicsBased pm;

    public float HookedDistance;
    bool creatJoint = false;
    SpringJoint joint;
    SpringJoint joint2;

    public LayerMask layerMask;

    private void Start()
    {
        cam =FindObjectOfType<Camera>();
        pm = FindObjectOfType<PlayerMovementPhysicsBased>();
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
            StopHooking();


        }

        if (Firing)
        {
            if (!IsHooked)
            {
                Hook.transform.position = Vector3.MoveTowards(Hook.transform.position, hitPos, HookSpeed * Time.deltaTime);
            }
            currentDistance = Vector3.Distance(Hook.transform.position, hitPos);
            if (currentDistance <= 0.001f)
            {
                IsHooked = true;
            }

            if (Hooking)
            {
                if (creatJoint)
                {
                    creatJoint = false;

                    HookedDistance = Vector3.Distance(hitPos, Rope.transform.position);

                    joint = FindObjectOfType<PlayerMovementPhysicsBased>().gameObject.AddComponent<SpringJoint>();

                    joint.autoConfigureConnectedAnchor = false;
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        joint.connectedBody = hit.transform.GetComponent<Rigidbody>();
                        joint.connectedAnchor = hit.transform.InverseTransformPoint(hitPos);
                    }
                    else
                    {
                        joint.connectedAnchor = hitPos;
                    }



                    joint.spring = 100f; //4.5f;
                    joint.damper = 70f;
                    joint.massScale = 4.5f;
                    joint.enableCollision = true;

                    Hook.transform.parent = hit.transform;

                }

                joint.minDistance = 0.6f;
                joint.maxDistance = HookedDistance;

                if (Input.GetMouseButton(1))  //right clicking white hooked
                {
                    HookedDistance -= PullForce * Time.deltaTime;

                    if (hit.transform.GetComponent<Farmland>())
                    {
                        hit.transform.GetComponent<Farmland>().HarvestCrop();

                        StopHooking();
                    }
                }

            }
            

            if (currentDistance <= 0.1f && !Hooking)
            {
                StopHooking();
            }
        }
        else
        {
            Hook.transform.localPosition = Vector3.MoveTowards(Hook.transform.localPosition, Vector3.zero, HookSpeed * 2 * Time.deltaTime);
            Destroy(joint);
           
        }
    }
        
    void StopHooking()
    {
        Firing = false;
        IsHooked = false;
        Hook.transform.parent = Rope.transform;
        Hook.transform.rotation = Rope.transform.rotation;
    }

    void StartGrappling()
    {
        
        Vector3 point = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(point);

        if (Physics.Raycast(ray, out hit, GS.GrappleDist, layerMask))
        {
            hitPos = hit.point;

            if (hit.transform.gameObject.layer == 6)
            {
                Hooking = true;
                pm.IsHooked = true;

                creatJoint = true;
            }
            else
            {
                Hooking = false;
                pm.IsHooked = false;
            }
            
        }
        else
        {
            Hooking = false;
            pm.IsHooked = false;
            hitPos = Rope.transform.position + (Rope.transform.forward * GS.GrappleDist);
        }
    }
}
