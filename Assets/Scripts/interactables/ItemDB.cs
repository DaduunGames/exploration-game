using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemDB
{
    public enum Items {
        empty,
        stoneSeed,
        woodenPlankSeed,
        grapplingHook
    }

    public static List<ItemConstructor> ItemLibrary = new List<ItemConstructor>()
    {
        new ItemConstructor("Empty",ItemConstructor.ItemType.Seed, Crop.Type.Empty, 1, 999, 3),
        new ItemConstructor("Stone Seed",ItemConstructor.ItemType.Seed, Crop.Type.Stone, 1, 999, 3),
        new ItemConstructor("Wooden Plank Seed",ItemConstructor.ItemType.Seed, Crop.Type.WoodenPlank, 1, 999, 3),

        new ItemConstructor("Grappling Hook", ItemConstructor.ItemType.Grapplehook, 0, 1, 1, 3)
    };

    public static List<Crop> CropLibrary = new List<Crop>()
    {
        new Crop(Crop.Type.Empty, 0, "", "", 0),
        new Crop(Crop.Type.Stone, 0.1f,"StoneCrop","", 1),
        new Crop(Crop.Type.WoodenPlank, 0.2f,"WoodenPlankCrop","", 2)
    };
    public static Crop NewCrop(Crop.Type type)
    {
        Crop r = CropLibrary[(int)type];
        Crop newCrop = new Crop(r.type, r.growRate, r.prefab, r.image, r.itemIndex);
        return newCrop;
    }

    
}
