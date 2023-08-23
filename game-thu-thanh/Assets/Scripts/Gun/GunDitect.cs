using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDitect : MonoBehaviour
{
    public GunCtrl gunCtrl;
    public EnemyCtrl target;
    private List<EnemyCtrl> listTarget;


    private void Awake() {
        gunCtrl = GetComponent<GunCtrl>();
    }

    void Start()
    {
        listTarget = new List<EnemyCtrl>();
        target = null;
    }

    private void FixedUpdate() {
        CheckEnemyDeadOrOut();
    }

    private void ChooseTarget () {
        if (listTarget.Count <= 0) {
            SetTarget(null);
        } else {
            SetTarget(listTarget[0]);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.TryGetComponent(out EnemyCtrl enemy)) {
            listTarget.Add(enemy);
            ChooseTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D target) {
        if (target.TryGetComponent(out EnemyCtrl enemy)) {
            for(int i =0; i<listTarget.Count; i++) {
                if(listTarget[i].getId() == enemy.getId()) {
                    listTarget.RemoveAt(i);
                    ChooseTarget();
                    // return;
                }
            }
        }

    }

    private void CheckEnemyDeadOrOut() {
        if(listTarget.Count <= 0) return;
        for(int i =0 ; i< listTarget.Count; i++) {
            if (listTarget[i]== null ) {
                listTarget.RemoveAt(i);
                ChooseTarget();
            }
        }
        
    }


    private void SetTarget(EnemyCtrl enemyCtrl) {
        target = enemyCtrl;
    }

    public EnemyCtrl GetTarget() {
        return target;
    }

    
}
