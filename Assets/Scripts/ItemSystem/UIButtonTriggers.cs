using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonTriggers : MonoBehaviour
{
    public void LoadGame(int index)
    {
        GS.LoadGame(index);
    }
}
