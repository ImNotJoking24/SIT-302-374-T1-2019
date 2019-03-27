using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public int depth;
    public int width = 256;
    public int height = 256;
    public float scale = 1f;

    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }
    // Update is called once per frame
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x<width; x++)
        {
            for(int y = 0; y<height; y++)
            {
                float xCoord = (float) x / (float) width * scale;
                float yCoord = (float) y / (float) height * scale;
                float xCoord2 = (float)x / (float)width * (scale*2);
                float yCoord2 = (float)y / (float)height * (scale*2);
                float xCoord3 = (float)x / (float)width * (scale*4);
                float yCoord3 = (float)y / (float)height * (scale*4);
                float xCoord4 = (float)x / (float)width * (scale*8);
                float yCoord4 = (float)y / (float)height * (scale*8);

                heights[x, y] = (8.0f / 15.0f) * Mathf.PerlinNoise(xCoord, yCoord)+
                   (4.0f / 15.0f) * Mathf.PerlinNoise(xCoord2+1000, yCoord2+1000) + 
                    (2.0f / 15.0f) * Mathf.PerlinNoise(xCoord3 + 2000, yCoord3 + 2000)
                    + (1.0f / 15.0f) * Mathf.PerlinNoise(xCoord4 + 3000, yCoord4 + 3000);
            }
        }
        return heights;
    }

   
}
