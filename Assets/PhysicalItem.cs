using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : TriggerCore
{

    public ItemConstructor ic = ItemDB.ItemLibrary[(int)ItemDB.Items.empty];

    public void Init(ItemConstructor Item)
    {
        ic = Item;
    }

    public override void Trigger()
    {
        FindObjectOfType<Hotbar>().AddToInventory(ic);
        Destroy(gameObject);
    }
}
