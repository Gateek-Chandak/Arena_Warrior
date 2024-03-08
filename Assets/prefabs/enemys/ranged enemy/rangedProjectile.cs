using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject hitEffect;

    private playerHealth playerHealth;

    private Transform player;
    private Vector2 target;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            attack();
        }
    }

    void attack()
    {
        Destroy(gameObject);
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        playerHealth.loseHealth(damage);
    }
}
