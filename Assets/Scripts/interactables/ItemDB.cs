using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemDB
{
    public enum Items {
        empty = -1,
        stoneSeed = 1,
        woodenPlankSeed,
        metalSeed,
        tableSeed,
        chairSeed,
        yarnBallSeed,
        clothSeed,
        paperSeed, 
        bookSeed,
        torchSeed,
        coalSeed,
        ropeSeed,
        magicalCircuitSeed,
        ruinCobbleSeed,
        cogSeed,
        ingotSeed,
        
        cobble,
        woodenPlank,
        metal,

        grapplingHook
    }

    public static List<ItemConstructor> ItemLibrary = new List<ItemConstructor>()
    {
        //ALL SEED GO ONTOP
        new ItemConstructor("Empty","",999,"default","default","default",ItemConstructor.ItemType.Empty,Crop.Type.Empty),

        new ItemConstructor("Cobble Seed","",999,"cobble","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Stone),
        new ItemConstructor("Wooden Plank Seed","",999,"wooden_plank","default","default",ItemConstructor.ItemType.Seed,Crop.Type.WoodenPlank),
        new ItemConstructor("Metal Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Metal),
        new ItemConstructor("Table Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Table),
        new ItemConstructor("Chair Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Chair),

        new ItemConstructor("Yarn Ball Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.YarnBall),
        new ItemConstructor("Cloth Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Cloth),
        new ItemConstructor("Paper Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Paper),
        new ItemConstructor("Book Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Book),
        new ItemConstructor("Torch Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Torch),
        

        new ItemConstructor("Coal Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Coal),
        new ItemConstructor("Rope Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Rope),
        new ItemConstructor("Magical Circuit Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.MagicalCircuit),
        new ItemConstructor("Ruin Cobble Seed","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.RuinCobble),
        
        new ItemConstructor("Cog","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Cog),
        new ItemConstructor("Ingot","",999,"default","default","default",ItemConstructor.ItemType.Seed,Crop.Type.Ingot),

        // ALL HARVESTED PRODUCTS GO STRAIGHT AFTER ALL CROPS
        new ItemConstructor("Cobble", "", 999, "default", "default", "default", ItemConstructor.ItemType.Material, Crop.Type.Empty),
        new ItemConstructor("Wooden Plank", "", 999, "default", "default", "default", ItemConstructor.ItemType.Material, Crop.Type.Empty),
        new ItemConstructor("Metal", "", 999, "default", "default", "default", ItemConstructor.ItemType.Material, Crop.Type.Empty),

        //EVERY OTHER ITEM GOES DOWN HERE
        new ItemConstructor("Grappling Hook","Your new best friend",1,"default","default","grapplehook",ItemConstructor.ItemType.Grapplehook,Crop.Type.Empty)
        
    };

    public static List<Crop> CropLibrary = new List<Crop>()
    {
        new Crop(Crop.Type.Empty, 0, "default"),

        new Crop(Crop.Type.Stone, 0.1f,"CobbleCrop"),
        new Crop(Crop.Type.WoodenPlank, 0.2f,"WoodenPlankCrop"),
        new Crop(Crop.Type.Metal, 0.2f, "default"),
        new Crop(Crop.Type.Table, 0.2f, "default"),
        new Crop(Crop.Type.Chair, 0.2f, "default"),

        new Crop(Crop.Type.YarnBall, 0.2f, "default"),
        new Crop(Crop.Type.Cloth, 0.2f, "default"),
        new Crop(Crop.Type.Paper, 0.2f, "default"),
        new Crop(Crop.Type.Book, 0.2f, "default"),
        new Crop(Crop.Type.Torch, 0.2f, "default"),
       

        new Crop(Crop.Type.Coal, 0.2f, "default"),
        new Crop(Crop.Type.Rope, 0.2f, "default"),
        new Crop(Crop.Type.MagicalCircuit, 0.2f, "default"),
        new Crop(Crop.Type.RuinCobble, 0.2f, "default"),
        new Crop(Crop.Type.Cog, 0.2f, "default"),

        new Crop(Crop.Type.Ingot, 0.2f, "default"),
    };
    public static Crop NewCrop(Crop.Type type)
    {
        Crop r = CropLibrary[(int)type];
        Crop newCrop = new Crop(r.type, r.growRate, r.prefab);
        return newCrop;
    }

    
}
