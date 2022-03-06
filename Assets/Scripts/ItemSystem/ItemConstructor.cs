using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConstructor
{
    public string Name = "";
    public string Description = "";
    public int ammount = 1;
    public int maxAmmount = 999;
    public string image;
    public string physicalPrefab;
    public string handPrefab;

    public ItemType itemType = ItemType.Empty;
    public Crop.Type cropType;
    public enum ItemType
    {
        Empty,
        Seed,
        Grapplehook,
        Material
    }

    public ItemConstructor(string name, string description, int MaxAmmount, string Image, string PhysicalPrefab, string HandPrefab, ItemType ItemType, Crop.Type CropType)
    {
        Name = name;
        Description = description;
        maxAmmount = MaxAmmount;
        image = "Items/Images/" + Image;
        physicalPrefab = "Items/PhysicsPrefabs/" + PhysicalPrefab;
        handPrefab = "Items/HandPrefabs/" + HandPrefab;

        itemType = ItemType;
        cropType = CropType;
    }
}
