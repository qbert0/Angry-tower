using UnityEngine;

public class TowerPanel : MonoBehaviour
{
    [SerializeField] private GridCtrl gridCtrl;
    private void Start() {
        gridCtrl = FindObjectOfType<GridCtrl>();
    }

    private GameObject towerPrefab;
    public GameObject TowerPrefab { 
        get {
            return towerPrefab;
        }
    }
    
    public void PutTower() {
        gridCtrl.PutTower(TowerPrefab);
    }

    public void HighLight() {
        gridCtrl.HighLight();
    }

    public void PickTower(GameObject towerPrefab) {
        this.towerPrefab = towerPrefab;
        Debug.Log("on panel");
    }
}
