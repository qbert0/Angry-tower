using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridTile))]
public class SaveLoadMap : MonoBehaviour
{
    [SerializeField] MapData mapData;
    [SerializeField] GridTile gridTile;
    [SerializeField] GridManager gridManager;

    public void Save() {
        bool[,] map = gridManager.ReadTileMap();
        mapData.Save(map);
    }

    public void Load() {
        gridManager.Clear();
        gridManager.Load(mapData);
    }

    internal void Load(GridTile gridTile) {
        mapData.Load(gridTile);
    }
}
