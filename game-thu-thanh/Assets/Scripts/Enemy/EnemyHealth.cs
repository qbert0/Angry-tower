using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealtSystem
{
    public class EnemyHealth : MonoBehaviour
{

    private enum Character {
        Enemy, 
        House 
    }
    [SerializeField] private Character character;
    [SerializeField] private float hitPoints = 0;
    [Range(1f,50f)]
    [SerializeField] private float maxHitPoint = 50;
    
    public HealthBar healthBar;
    private GameManager gameManager;

    
    void Start()
    {

        if (healthBar != null) {
            healthBar.setMaxHealth( maxHitPoint);
        }
        if(character == Character.House) {
            healthBar.SetActive(true);
            gameManager = FindObjectOfType<GameManager>();
        }
        hitPoints = maxHitPoint;
    }


    public void TakeHit(float damage) {
        hitPoints -= damage;
        healthBar.setHealth(hitPoints);
        if (hitPoints <= 0) {
            if (character == Character.House) {
                GameOver();
            }
            Destroy(gameObject);
        }
    }

    private void GameOver() {
        gameManager.gameOnly.GameOver();
    }
}
}
