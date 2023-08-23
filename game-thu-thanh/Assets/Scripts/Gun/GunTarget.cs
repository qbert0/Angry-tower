using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTarget : MonoBehaviour
{
    private EnemyCtrl target;


    public void SetTarget(EnemyCtrl enemyMovement) {
        target = enemyMovement;
    }

    public EnemyCtrl GetTarget() {
        return target;
    }
}
