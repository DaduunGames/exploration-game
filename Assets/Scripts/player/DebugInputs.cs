using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInputs : MonoBehaviour
{
    public ItemDB.Items[] spawningItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GS.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GS.LoadGame(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            GS.ClearSaveData();
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) 
        {
            foreach(ItemDB.Items item in spawningItem)
            {
                FindObjectOfType<Hotbar>().AddToInventory(ItemDB.ItemLibrary[(int)item]);
            }
            
        }
        
    }
}
