using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureTiler : MonoBehaviour
{
    public bool UpdateScale = false;

    public Vector2[] Scales;
    //public Material[] tempMats;

    int length;

    void Awake()
    {
        Init();
    }


    
    void Update()
    {
        if (UpdateScale)
        {
            UpdateScale = false;

            

            for (int i = 0; i < length; i++)
            {
                GetComponent<Renderer>().materials[i].mainTextureScale = Scales[i];
            }

            Init();
        }
       
    }

    private void Init()
    {
        length = GetComponent<Renderer>().sharedMaterials.Length;
       

        Scales = new Vector2[length];
        for(int i = 0; i < length; i++)
        {
            Scales[i] = GetComponent<Renderer>().sharedMaterials[i].mainTextureScale;
        }


        
    }
}
