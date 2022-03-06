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
        new ItemConstructor("Empty","",999,"default","default","default",ItemConstructor.ItemType.Empty,Crop.Type.Empty),

        new ItemConstructor("Stone Seed","Produces small cobblestones.",999,"stone","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Stone),
        new ItemConstructor("Wooden Plank Seed","Produces an unnaturally refined woodenplank.",999,"wooden_plank","default","default",ItemConstructor.ItemType.Seed,Crop.Type.WoodenPlank),

        new ItemConstructor("Grappling Hook","Your new best friend",1,"default","default","grapplehook",ItemConstructor.ItemType.Grapplehook,Crop.Type.Empty)
        
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
