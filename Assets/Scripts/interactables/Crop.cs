using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop
{
    public Type type = Type.Empty;

    public float age = 0f;
    public float growRate = 1f;

    public string prefab = "";
    //public string image = "";

    //public int itemIndex = 0;

    public enum Type
    {
        Empty = 0,
        Stone = 1,
        WoodenPlank = 2,
        Table = 3,
        Chair = 4,
        YarnBall = 5,
        Cloth = 6,
        Paper = 7,
        Book = 8,
        Torch = 9,
        Metal = 10,
        Coal = 11,
        Rope = 12,
        MagicalCircuit = 13,
        RuinCobble = 14,
        Cog = 15,
        Ingot = 16
    }

    public Crop()
    {
        type = Type.Empty;
    }

    public Crop(Type CropType, float GrowRate, string Prefab)
    {
        type = CropType;
        growRate = GrowRate;
        prefab = Prefab;
        //image = Image;
        //itemIndex = ItemIndex;
    }
}
