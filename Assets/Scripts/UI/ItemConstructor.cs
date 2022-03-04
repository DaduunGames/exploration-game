using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConstructor
{
    public string Name = "";
    public ItemType itemType = ItemType.Empty;
    public Crop.Type cropType;
    public int ammount = 1;
    public int maxAmmount = 999;
    public float raycastDist = 3;
    public enum ItemType
    {
        Empty,
        Seed,
        Grapplehook,
        Material
    }

    public ItemConstructor(string name, ItemType ItemType, Crop.Type CropType,int Ammount, int MaxAmmount, int RaycastDist)
    {
        itemType = ItemType;
        cropType = CropType;
        ammount = Ammount;
        maxAmmount = MaxAmmount;
        raycastDist = RaycastDist;
        Name = name;
    }
}
