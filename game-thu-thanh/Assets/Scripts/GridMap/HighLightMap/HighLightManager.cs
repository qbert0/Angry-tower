using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighLightManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileSet highLight;
    void Start()
    {
        HighLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighLight() {
        for(int x =0; x < 5; x++) {
            for(int y =0; y < 5; y++) {
                tilemap.SetTile(new Vector3Int(x,y,0), highLight.tiles[0]);
            }
        }
    }
}
