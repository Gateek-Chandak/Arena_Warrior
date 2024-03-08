using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    public enemy card;
    public float health;

    private playerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    void Update()
    {
        if (health <= 0)
        {
            die();
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            Instantiate(card.hitEffect, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && card.typeOfEnemy == "combat")
        {
            combatType();
        }
    }

    void combatType()
    {
        health = 0;
        playerHealth.loseHealth(card.damage);
    }

    void die()
    {
        Instantiate(card.deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        scoreManager.addScore(card.scoreToGive);
    }
}
