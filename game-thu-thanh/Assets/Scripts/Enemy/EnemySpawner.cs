using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GridManager gridManager;
    [Range(0.1f, 0.5f)]
    [SerializeField] private float spawnRate = 0.1f;
    [Range(1f,5f)]
    [SerializeField] private float timeBetweenWave = 5f;
    [SerializeField] EnemyCtrl enemyPrefabs;
    [Range(1,20)]
    [SerializeField] private int enemyCount;
    [SerializeField] private bool canSpawn;
    [SerializeField] private Transform parent;
    public SpawnCtrl spawnCtrl;
    private bool waveIsDone = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = gridManager.GetWorldToCenterCell(transform.position);
        spawnCtrl = GetComponent<SpawnCtrl>();
    }

    void Update()
    {
        if(!canSpawn) {
            return;
        }
        if (waveIsDone) {
            StartCoroutine(WaveSpawner());
        }
    }

    private IEnumerator WaveSpawner() {
        waveIsDone = false;
        for (int i=0; i<enemyCount; i++ ) {
            EnemyCtrl enemyClone = Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
            
            enemyClone.name = "clam";
            enemyClone.SetId(i);
            // Debug.Log(enenmyRoad.GetRoad().Count);
            enemyClone.enemyMovement.TakeRoad(spawnCtrl.enenmyRoad.GetRoad());
            enemyClone.transform.SetParent(parent);
            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWave);
        waveIsDone = true;
    }

    public void SetSpawn(bool spawn) {
        this.canSpawn = spawn;
    }

    public void ToggleSpawn() {
        this.canSpawn = !this.canSpawn;
    }

}
