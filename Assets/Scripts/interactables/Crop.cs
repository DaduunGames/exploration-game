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
        Empty,
        Stone,
        WoodenPlank,
        Metal,
        Table,
        Chair,
        YarnBall,
        Cloth,
        Paper,
        Book,
        Torch,
        
        Coal,
        Rope,
        MagicalCircuit,
        RuinCobble,
        Cog ,
        Ingot
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
