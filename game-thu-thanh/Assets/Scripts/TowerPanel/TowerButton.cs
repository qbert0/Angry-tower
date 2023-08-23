using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private TowerPanel towerPanel;

    public GameObject TowerPrefab { 
        get {
            return towerPrefab;
        }  
    }

    [SerializeField] private TowerHover towerHover;

    private TowerHover virTowerHover;

    private void Start() {
        towerPanel = FindObjectOfType<TowerPanel>();
    }

    public void Enter() {
        Debug.Log("eneter");
    }
    public void Exit() {
        Debug.Log("exit");
    }
    public void Up() {
        virTowerHover.DeActivate();
        towerPanel.PutTower();
    }
    public void Drag() {
        virTowerHover.FollowMouse();
        towerPanel.HighLight();
    }
    public void Down(Image image) {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        virTowerHover = Instantiate(towerHover, pos, Quaternion.identity);
        virTowerHover.Activate(image.sprite);
        towerPanel.PickTower(this.towerPrefab);

    }
}
