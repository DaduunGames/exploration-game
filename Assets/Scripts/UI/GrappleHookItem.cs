using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookItem : Item
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


    public Attachment attachment;
    Camera cam;
    float interactDist = 3;

    RaycastHit hit;

    public enum Attachment 
    {
        Hook,
        BoxingGlove
    }

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    public override void UseItem()
    {
        switch (attachment)
        {
            case Attachment.Hook:
                hit = GrappleRaycast();

                //test for farmland
                if (hit.transform) 
                {
                    Farmland fl = hit.transform.GetComponent<Farmland>();
                    if (fl)
                    {
                        fl.HarvestCrop();
                    }
                }

                return;
            case Attachment.BoxingGlove:
                hit = GrappleRaycast();

                return;
        }
    }


    RaycastHit GrappleRaycast()
    {
        RaycastHit tempHit;
        Vector3 point = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(point);

        Physics.Raycast(ray, out tempHit, interactDist);

        return tempHit;
            
    }

    public override void AddItem(int Amount)
    {

    }

    public override void RemoveItem(int Amount)
    {

    }
}
