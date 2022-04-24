using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : TriggerCore
{

    public ItemConstructor ic = ItemDB.ItemLibrary[0];

    public void Init(ItemConstructor Item)
    {
        ic = Item;
        GameObject obj = Resources.Load<GameObject>(ic.physicalPrefab);
        Instantiate(obj, transform.position, transform.rotation, transform);
    }

    public override void Trigger()
    {
        bool freeSlot = FindObjectOfType<Hotbar>().AddToInventory(ic);
        if(freeSlot) Destroy(gameObject);
    }
}
