using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public EnenmyRoad enenmyRoad;

    private void Awake() {
        enemySpawner = GetComponent<EnemySpawner>();
        enenmyRoad = GetComponent<EnenmyRoad>();
    }
}
