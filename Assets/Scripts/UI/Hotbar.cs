using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject slotParent;
    Slot[] slots;

    public int selectedSlot;

    public GameObject highlight;

    public GameObject BaseITemUI;

    private void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        BaseITemUI = Resources.Load<GameObject>("Items/HotbarItem");
    }

    private void Update()
    {
        #region switch hotbar slots
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar0]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar0]))
        {
            selectedSlot = 0;
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar1]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar1]))
        {
            selectedSlot = 1;
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar2]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar2]))
        {
            selectedSlot = 2;
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar3]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar3]))
        {
            selectedSlot = 3;
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar4]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar4]))
        {
            selectedSlot = 4;
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar5]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar5]))
        {
            selectedSlot = 5;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0) selectedSlot--;
        if (Input.GetAxis("Mouse ScrollWheel") < 0) selectedSlot++;

        if (selectedSlot > 5) selectedSlot = 0;
        if(selectedSlot < 0) selectedSlot = 5;

        #endregion

        highlight.transform.position = slots[selectedSlot].transform.position;

        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.LeftClick]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.LeftClick]))
        {
            if(slots[selectedSlot].transform.childCount > 0)
            slots[selectedSlot].GetComponentInChildren<Item>().UseItem();
        }
    }

    public void AddToInventory(ItemConstructor ic)
    {
        print("attempting to add item to slot");
        GameObject foundSlot = null;
        foreach (Slot slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                Item item = slot.transform.GetChild(0).GetComponent<Item>();
                if (item.Name == ic.Name)
                {
                    item.amount += ic.ammount;
                    return;
                }
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                foundSlot = slot.gameObject;
                break;
            }
        }
        print("slot found: " + foundSlot.name);

        if (foundSlot)
        {
            GameObject ItemObj = Instantiate(BaseITemUI, foundSlot.transform.position, foundSlot.transform.rotation, foundSlot.transform);


            switch (ic.itemType)
            {
                case ItemConstructor.ItemType.Grapplehook:
                    ItemObj.AddComponent<GrappleHookItem>();
                    return;


                case ItemConstructor.ItemType.Seed:
                    ItemObj.AddComponent<Seed>();
                    Seed seed = ItemObj.GetComponent<Seed>();
                    seed.cropType = ic.cropType;
                    seed.Name = ic.Name;
                    seed.amount = ic.ammount;
                    seed.MaxStack = ic.maxAmmount;
                    seed.interactDist = ic.raycastDist;
                    return;


                case ItemConstructor.ItemType.Material:
                    //TODO: materials
                    return;
            }
        }
        else
        {
            Debug.Log("Not free hotbar slots available");
        }
        
    }
}
