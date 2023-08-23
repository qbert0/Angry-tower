using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health=100;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            takeDamage(20);
        }
    }

    private void takeDamage(int damage) {
        health -= damage;
        healthBar.setHealth(health);
        if(health <= 0) {
            health =0;
        }
    }
}
