using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    public Crop.Type cropType;

    Camera cam;
    public float interactDist = 3;

    public Seed(Crop.Type type)
    {
        cropType = type;
    }

    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    public override void UseItem()
    {
        Debug.Log("attmepting to plant seed");

        RaycastHit hit;
        Vector3 point = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(point);
       
        if (Physics.Raycast(ray, out hit, interactDist))
        {
            
            Farmland fl = hit.transform.GetComponent<Farmland>();
            if (fl)
            {
                
                bool hasUsed = fl.PlantCrop(ItemDB.NewCrop(cropType));
                if (hasUsed) RemoveItem(1);
            }
        }
        else
        {
            Debug.Log("raycast failed");
        }
    }

    
}
