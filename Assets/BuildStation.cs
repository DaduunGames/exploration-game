using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildStation : TriggerCore
{
    public StructureBase[] Structures;
    public int currentStructure = 0;

    Hotbar hotbar;
    public TextMeshPro Display;

    private void Start()
    {
        hotbar = FindObjectOfType<Hotbar>();
        SetText();
    }

    public override void Trigger()
    {
        if (currentStructure == Structures.Length - 1) return;
        bool success = true;
        foreach(ItemAndAmount ia in Structures[currentStructure+1].Cost)
        {
            if (!hotbar.Checkfor(ia))
            {
                success = false;
            }
        }

        if (success)
        {
            UpgradeStructure();
            
        }

    }

    void UpgradeStructure()
    {
        foreach (ItemAndAmount ia in Structures[currentStructure + 1].Cost)
        {
            hotbar.RemoveFromInventory(ia);
        }


        foreach (StructureBase sb in Structures)
        {
            sb.obj.SetActive(false);
        }
        
        ++currentStructure;
        Structures[currentStructure].obj.SetActive(true);

        if (currentStructure >= Structures.Length - 1)
        {
            Destroy(gameObject);
        }

        SetText();
    }

    void SetText()
    {
        string txt = "";
        foreach(ItemAndAmount ia in Structures[currentStructure+1].Cost)
        {
            txt += $"\n {ia.amount} x {ItemDB.ItemLibrary[(int)ia.item].Name}";
        }
        Display.text = txt;
    }
}
