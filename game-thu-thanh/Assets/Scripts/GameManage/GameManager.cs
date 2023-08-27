using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] public GameOnly gameOnly;
    [SerializeField] public Display display;


    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    

    public void CanSpawn(bool to = true) {
        if(enemySpawner == null) {
            Debug.LogError("enemy spawn is null");
        }
        enemySpawner.SetSpawn(to);
    }

}
