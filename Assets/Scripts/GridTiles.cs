using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTiles : MonoBehaviour
{
    public GameObject TilePrefab;
    public Material MaterialBase;
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
        //Instantiate(Tile,pos3d,Quaternion.identity);
        GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tile.transform.localScale = new Vector3(0.5f,0.25f, 0.5f);
        tile.transform.position = pos3d;
        var tilerend = tile.GetComponent<Renderer>();
        tilerend.material = MaterialBase;
        tilerend.material.color = RandomColor();
    }

    Color RandomColor()
    {
        float rc = Random.Range(0f,1f);
        float gc = Random.Range(0f,1f);
        float bc = Random.Range(0f,1f);
        return new Color(rc, gc, bc);
    }
}
