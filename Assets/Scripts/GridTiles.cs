using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTiles : MonoBehaviour
{
    public GameObject Tile;
    public BoundsInt Size;
    public float OffsetMult = 2f;
    public Dictionary<Vector2Int, GameObject> Tiles;

    void Start()
    {
        foreach(var pos in Size.allPositionsWithin)
        {
            CreateTile(pos);
        }
    }

    void Update()
    {
        //
    }

    void CreateTile(Vector3 pos)
    {
        Vector3 pos3d = new Vector3(pos.x/OffsetMult, 0.0f, pos.z/OffsetMult);
        Instantiate(Tile,pos3d,Quaternion.identity);
    }
}
