using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name = "";
    public string Description = "";
    public int amount = 1;
    public int maxAmmount = 999;
    public string Image = "Items/Images/default";
    public string PhysicsPrefab = "Items/PhysicsPrefabs/default";
    public string HandPrefab = "Items/HandPrefabs/default";

    public virtual void AddItem(int Amount)
    {
        amount += Amount;
    }

    public virtual void RemoveItem(int Amount)
    {
        amount -= Amount;

        if (amount <= 0)
        {
            Destroy(FindObjectOfType<Hotbar>().hand.transform.GetChild(0).gameObject);
            Destroy(gameObject);
        }
    }

    public virtual void UseItem() { }

    public void SetItem(ItemConstructor constructor)
    {
        Name = constructor.Name;
        Description = constructor.Description;
        amount = constructor.ammount;
        maxAmmount = constructor.maxAmmount;
        Image = constructor.image;
        PhysicsPrefab = constructor.physicalPrefab;
        HandPrefab = constructor.handPrefab;
    }

}
