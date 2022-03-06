using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookItem : Item
{
    public Attachment attachment;

    public float RopeSpeed = 10;

    public enum Attachment 
    {
        Hook,
        BoxingGlove
    }


    public override void UseItem()
    {
        
    }

    public override void AddItem(int Amount)
    {

    }

    public override void RemoveItem(int Amount)
    {

    }
}
