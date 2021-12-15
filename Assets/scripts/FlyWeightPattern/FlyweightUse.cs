using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FlyweightUse : MonoBehaviour
{
    public Tilemap tilemap;
    Dictionary<string, Tile> dic = new Dictionary<string, Tile>();
    public Tile gressTile;

    public Tile getgressTile()
    {
        if (!dic.ContainsKey("gressTile"))
        {
            dic.Add("gressTile", gressTile);
        }
        return dic["gressTile"];
    }

    // Start is called before the first frame update
    void Start()
    {
        Tile gressTile = getgressTile();
        tilemap.SetTile(Vector3Int.zero, gressTile);
        tilemap.SetTile(Vector3Int.right, gressTile);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TileFactory : MonoBehaviour
{

}

