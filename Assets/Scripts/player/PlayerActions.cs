using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Camera cam;
    public float PickupDistance = 3;
    


    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }


    void Update()
    {
        //interact
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Interact]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Interact]))
        {
            RaycastHit hit;
            Vector3 point = new Vector3(0.5f, 0.5f, 0);
            Ray ray = cam.ViewportPointToRay(point);

            if (Physics.Raycast(ray, out hit, PickupDistance))
            {
                
            }
        }
    }
}
