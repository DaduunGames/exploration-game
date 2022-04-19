using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmland : MonoBehaviour
{
    Crop currentCrop;
    GameObject prefab = null;

    public Crop.Type WildCrop;
    public bool isWild;

    private GameObject Physical;
    public Vector3 offset;
    public float HarvestFlingForce = 1;

    private void Start()
    {
        currentCrop = new Crop();

        Physical = Resources.Load<GameObject>("Items/PhysicalItem");

        if (isWild)
        {
            PlantCrop(ItemDB.NewCrop(WildCrop));
        }

    }


    private void Update()
    {
        

        if(currentCrop.type != Crop.Type.Empty)
        {
            GrowCrop();
        }
    }

    public bool PlantCrop(Crop crop)
    {
        //print("attempting to plant");
        if (currentCrop.type == Crop.Type.Empty)
        {
            //print("able to plant");
            //set crop
            currentCrop = crop;

            //find prefab
            GameObject cropPrefab;
            cropPrefab = Resources.Load<GameObject>("Crops/" + currentCrop.prefab);

            //spawn the prefab in
            prefab = Instantiate(cropPrefab, transform);
            prefab.transform.localScale = Vector3.one * currentCrop.age;

            return true;
        }
        else
        {
            //print("Something is already planted");
            return false;
        }
       
    }

    public void GrowCrop()
    {
        if (currentCrop.type != Crop.Type.Empty && prefab != null)
        {
            currentCrop.age += currentCrop.growRate * Time.deltaTime;
            currentCrop.age = Mathf.Clamp(currentCrop.age, 0, 1);
            prefab.transform.localScale = Vector3.one * currentCrop.age;
        }
    }

    public void HarvestCrop()
    {
        if (currentCrop.age >= 1)
        {
            int amount = Random.Range(1,3);
            for (int i = 0; i < amount; i++)
            {
                PhysicalItem temp = Instantiate(Physical, transform.position + offset, Quaternion.identity).GetComponent<PhysicalItem>();
                temp.Init(ItemDB.ItemLibrary[(int)currentCrop.type]) ;

                Vector3 force = new Vector3(
                    Random.Range(-0.5f, 0.5f),
                    Random.Range(1, 3),
                    Random.Range(-0.5f, 0.5f)
                    );
                temp.GetComponent<Rigidbody>().AddForce(force * HarvestFlingForce, ForceMode.Impulse);
            }
        }

        print("harveting crop");

        RemoveCrop();

        if (isWild)
        {
            PlantCrop(ItemDB.NewCrop(WildCrop));
        }
    }

    public void RemoveCrop()
    {
        Destroy(prefab);
        prefab = null;
        currentCrop = new Crop();
    }
}
