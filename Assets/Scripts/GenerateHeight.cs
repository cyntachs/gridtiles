using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHeight
{
    int ChunkSize = 16;
    int PosXOffset = 0;
    int PosYOffset = 0;

    public int[] GenerateHeightData(float NoiseScale = 200, float Magnitude = 15f, int Octaves = 6, float Persistance = 0.5f, float Lacunarity = 2f, float NoiseOffset = 99999)
    {
        // NoiseScale - noisemap scale
        // Magnitude - height magnitude
        // Octaves - layers of noise
        // Persistance - controls amplitude
        // Lacunarity - controls frequency
        // NoiseOffset - noise offset

        int[] Heightmap = new int[ChunkSize^2];

        // generate heightmap
        for (int i = 0; i < (ChunkSize^2); i++)
        {
            float xt = i % ChunkSize;
            float yt = (i / ChunkSize);
            xt += (PosXOffset) + NoiseOffset;
            yt += (PosYOffset) + NoiseOffset;

            float amplitude = 1f;
            float frequency = 1f;
            float height = 0;

            for (int o = 1; o < Octaves; o++)
            {
                float xv = xt / NoiseScale * frequency;
                float yv = yt / NoiseScale * frequency;

                float pval = Mathf.PerlinNoise(xv, yv);
                height += pval * amplitude;

                amplitude *= Persistance;
                frequency *= Lacunarity;
            }
            Heightmap[i] = Mathf.FloorToInt(height * Magnitude);
        }

        return Heightmap;
    }

    // set blocks
    /*for (int col = 0; col < GlobalCfg.Chunk.LayerBlockCount; col++)
    {
        for (int h = heightmap[col]; h < heightmap[col] + 2; h++)
        {
            if (h > heightmap[col])
                break;
            else
            {
                Block tblock = new Block();
                if (h > 16)
                    tblock.ID = 2; // debug
                else
                    tblock.ID = 1;
                tblock.MakeValid();
                _ChunkData.SetBlock(GlobalCfg.Chunk.LayerBlockCount * h + col, tblock);
            }
        }
    }*/
    /*for (int zc = 0; zc < ChunkSize; zc++)
    {
        for (int xc = 0; xc < ChunkSize; xc++)
        {
            TerrainVoxel tblock = new TerrainVoxel();
            int h = heightmap[xc + (ChunkSize * zc)];
            if (h > 16)
                tblock.Type = 2; // debug
            else
                tblock.Type = 1;
            tblock.MakeValid();
            _ChunkData.SetVoxelAt(new Vector3(xc, h, zc), tblock);
            _ChunkData.SetVoxelAt(new Vector3(xc, h-1, zc), tblock);
        }
    }*/
}
