using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridCtrl : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] HighLight highLight;
    [SerializeField] GridManager gridManager;
    [SerializeField] TowerPanel towerPanel;
    [SerializeField] GameObject listTower; // parent gameobject

    private Vector3 worldPoint; // in the world
    private Vector3Int posMouse;  // in the pos

    private void Start() {
        worldPoint = new Vector3();
        posMouse = new Vector3Int();
    }


    private void Mouse() {
        worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMouse = tilemap.WorldToCell(worldPoint);
    }

    public void HighLightPos(Vector3Int pos) {
        highLight.HighLightOnePos(pos);
    }

    public void HighLight() {
        Mouse();
        Clear();
        HighLightPos(posMouse);
        
    }

    public void PutTower(GameObject towerPrefab) {
        Clear();
        Mouse();
        if(CheckPutIsEnanle() == false) {
            return;
        }
        GameObject tower = Instantiate(towerPrefab, worldPoint, Quaternion.identity);
        tower.transform.SetParent(listTower.transform);
        highLight.PutTower();
    }
    public bool CheckPutIsEnanle() {
        return highLight.CheckPut();
    }
    public void Clear() {
        tilemap.ClearAllTiles();
    }
}
