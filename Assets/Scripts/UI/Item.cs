using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name = "";
    public int amount = 1;
    public int MaxStack = 999;

    public virtual void AddItem(int Amount)
    {
        amount += Amount;
    }

    public virtual void RemoveItem(int Amount)
    {
        amount -= Amount;

        if (amount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void UseItem() { }
}
