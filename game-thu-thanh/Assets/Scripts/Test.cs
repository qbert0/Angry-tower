using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
     [SerializeField] private TowerHover towerHover;

     private TowerHover virTowerHover;
    private void Start() {
        // virTowerHover = TowerHover();
    }

    // public void Enter() {
    //     Debug.Log("eneter");
    // }

    // public void Up() {
    //     virTowerHover.DeActivate();
    // }

    // public void Exit() {
    //     Debug.Log("exit");
    // }

    

    // public void Drag() {
    //     virTowerHover.FollowMouse();
    // }

    // public void Down() {
    //     Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     pos = new Vector3(pos.x, pos.y, 0);
    //     virTowerHover = Instantiate(towerHover, pos, Quaternion.identity);
    // }
}
