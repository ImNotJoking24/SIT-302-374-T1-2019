using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public int depth;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        Debug.Log("start");
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }
    // Update is called once per frame
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        Debug.Log("generating terrain");
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

                heights[x, y] = Mathf.PerlinNoise(xCoord,yCoord);
            }
        }
        return heights;
    }

   
}
