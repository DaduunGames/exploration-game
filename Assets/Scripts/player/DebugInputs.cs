using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInputs : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GS.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GS.LoadGame(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GS.ClearSaveData();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            FindObjectOfType<Hotbar>().AddToInventory(ItemDB.ItemLibrary[(int)ItemDB.Items.woodenPlankSeed]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FindObjectOfType<Hotbar>().AddToInventory(ItemDB.ItemLibrary[(int)ItemDB.Items.stoneSeed]);
        }
    }
}
