using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject slotParent;
    Slot[] slots;

    public int prevSelection;
    public int selectedSlot;

    public GameObject highlight;

    public GameObject BaseITemUI;

    public GameObject hand;

    private void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        BaseITemUI = Resources.Load<GameObject>("Items/HotbarItem");

        changeSlot(0);
    }

    private void Update()
    {
        #region switch hotbar slots
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar0]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar0]))
        {
            changeSlot(0);
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar1]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar1]))
        {
            changeSlot(1);
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar2]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar2]))
        {
            changeSlot(2);
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar3]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar3]))
        {
            changeSlot(3);
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar4]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar4]))
        {
            changeSlot(4);
        }
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Hotbar5]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Hotbar5]))
        {
            changeSlot(5);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            changeSlot(selectedSlot - 1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            changeSlot(selectedSlot + 1);
        }

        

        #endregion

        highlight.transform.position = slots[selectedSlot].transform.position;

        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Fire]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Fire]))
        {
            if(slots[selectedSlot].transform.childCount > 0)
            slots[selectedSlot].GetComponentInChildren<Item>().UseItem();
        }

        if(slots[prevSelection].transform.childCount > 0)
            slots[prevSelection].GetComponentInChildren<HotbarItemGUI>().PInfo.SetActive(false);
        if(slots[selectedSlot].transform.childCount > 0)
            slots[selectedSlot].GetComponentInChildren<HotbarItemGUI>().PInfo.SetActive(true);
    }

    private void changeSlot(int newSlot)
    {
        prevSelection = selectedSlot;
        selectedSlot = newSlot;

        if (selectedSlot > 5) selectedSlot = 0;
        if (selectedSlot < 0) selectedSlot = 5;

        if (hand.transform.childCount > 0)
        {
             Destroy(hand.transform.GetChild(0).gameObject);
        }

        if(slots[selectedSlot].transform.childCount > 0)
        {
            Item item = slots[selectedSlot].GetComponentInChildren<Item>();
            GameObject handPrefab = Resources.Load<GameObject>(item.HandPrefab);

            Instantiate(handPrefab, hand.transform.position, hand.transform.rotation, hand.transform);
        }
       
    }

    public bool AddToInventory(ItemConstructor ic)
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
                    return true;
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
        //print("slot found: " + foundSlot.name);

        if (foundSlot)
        {
            GameObject ItemObj = Instantiate(BaseITemUI, foundSlot.transform.position, foundSlot.transform.rotation, foundSlot.transform);


            switch (ic.itemType)
            {
                case ItemConstructor.ItemType.Grapplehook:
                    ItemObj.AddComponent<GrappleHookItem>();
                    break;


                case ItemConstructor.ItemType.Seed:
                    ItemObj.AddComponent<Seed>();
                    Seed seed = ItemObj.GetComponent<Seed>();
                    seed.cropType = ic.cropType;
                    break;


                case ItemConstructor.ItemType.Material:
                    //TODO: materials
                    ItemObj.AddComponent<MaterialItem>();
                    break;
            }

            ItemObj.GetComponent<Item>().SetItem(ic);

            return true;
        }
        else
        {
            Debug.Log("No free hotbar slots available");
            return false;
        }
        
    }

    public bool Checkfor(ItemAndAmount ia)
    {
        bool success = true;
        foreach(Slot slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                Item item = slot.transform.GetChild(0).GetComponent<Item>();

                if (ItemDB.ItemLibrary[(int)ia.item].Name == item.Name)
                {
                    if (ia.amount <= item.amount)
                    {
                        print("Found enough of: " + ia.item);
                        success = true;
                        break;
                    }
                    else
                    {
                        success = false;
                        print("Only found " + item.amount + "/" + ia.amount + " of: " + ia.item);
                    }
                }
                else
                {
                    success = false;
                    print("No " + ia.item + " found.");
                }
            }
        }
        return success;
    }


    public void RemoveFromInventory(ItemAndAmount ia)
    {
        foreach (Slot slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                Item item = slot.transform.GetChild(0).GetComponent<Item>();

                if (ItemDB.ItemLibrary[(int)ia.item].Name == item.Name)
                {
                    item.RemoveItem(ia.amount);
                }
            }
        } 
    }
}
