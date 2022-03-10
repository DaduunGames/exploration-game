using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DynamicTerrainTexture : MonoBehaviour
{
    Terrain terrain;
    TerrainMaterialMaster materials;

    public bool updateTextures;

    //[Header("Adjustables")]
    //public float GrassMaxSteepnes;


    float height;

    float highestPoint = -1;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        materials = transform.parent.GetComponent<TerrainMaterialMaster>();

        terrain.terrainData.terrainLayers = materials.layers;
    }

    private void Update()
    {
        if (updateTextures)
        {            
            UpdateTerrain();

            updateTextures = false;
        }
    }

    void UpdateTerrain()
    {
        print("Updating terrain textures");

        float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, 4];

        for (int y = 0; y < terrain.terrainData.alphamapWidth; y++)
        {
            for (int x = 0; x < terrain.terrainData.alphamapHeight; x++)
            {
                // Get the normalized terrain coordinate that
                // corresponds to the the point.
                float normX = x * (1.0f / (terrain.terrainData.alphamapWidth - 1));
                float normY = y * (1.0f / (terrain.terrainData.alphamapHeight - 1));

                float steepness = terrain.terrainData.GetSteepness(normX, normY) / 90;
                steepness = materials.GrassToStoneAlpha.Evaluate(steepness).a;
              
                height = terrain.terrainData.GetHeight(x, y) / terrain.terrainData.size.y;
                height = materials.SandToGrassAlpha.Evaluate(height).a;

                if (height > highestPoint)
                {
                    highestPoint = height;
                    //print(highestPoint);
                    //print(1 - height);
                }

                map[y, x, 0] = (float) (1- steepness) * height;
                map[y, x, 1] = (float) (steepness) * height;
                map[y, x, 2] = (float)1 - height;
                
            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, map);
        print("finnished");
    }
}
