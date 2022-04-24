using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerResources : MonoBehaviour
{
    public int maxHealth, health = 10;
    public float MaxStamina = 10;
    public int hunger, thirst = 5;
    public Vector3 pos = Vector3.zero;
    public Quaternion rot;

    

    private void Awake()
    {
        Debug.Log("world was reset");
        //GetResourceData();
        //LoadPos();
    }

    private void GetResourceData()
    {
        maxHealth = GS.gameData.p_maxHealth;
        health = GS.gameData.p_health;
        hunger = GS.gameData.p_hunger;
        thirst = GS.gameData.p_thirst;
        pos = GS.gameData.p_pos;
        rot = GS.gameData.p_rot;
    }

    private void LoadPos()
    {
        transform.position = pos;
        transform.rotation = rot;

        print("setting player postion from saved data");
    }
    
}
