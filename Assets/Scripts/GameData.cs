using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public GameData()
    {

    }

    public bool IsSet = false;

    public Keybinds savedKeybinds = new Keybinds();

    public int p_maxHealth, p_health, p_hunger, p_thirst = 10;
    public float p_maxStamina = 10;
    public Vector3 p_pos = new Vector3(0, 20, 0);
    public Quaternion p_rot = Quaternion.identity;


    public void GetWorld()
    {
        GetSettings();

        PlayerResources playerResources = Object.FindObjectOfType<PlayerResources>();
        
        p_maxHealth = playerResources.maxHealth;
        p_health = playerResources.health;
        p_hunger = playerResources.hunger;
        p_thirst = playerResources.thirst;
        p_maxStamina = playerResources.MaxStamina;
        p_pos = playerResources.transform.position;
        p_rot = playerResources.transform.rotation;
    }

    public void SetWorld()
    {

        SetSettings();

        IsSet = true;    
    }

    public void GetSettings()
    {
        savedKeybinds = GS.GetKeybinds();
    }
    public void SetSettings()
    {
        GS.SetKeybinds(savedKeybinds);
    }
}
