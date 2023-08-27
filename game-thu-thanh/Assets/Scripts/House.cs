using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealtSystem;

public class House : MonoBehaviour
{
    [SerializeField]  private EnemyHealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent(out EnemyCtrl enemy)) {
            enemyHealth.TakeHit(enemy.GetDamage());
            enemy.Death();
        }
    }
}
