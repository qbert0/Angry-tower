using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName = "tile set")]
public class TileSet : ScriptableObject
{
    public List<TileBase> tiles; 
}
