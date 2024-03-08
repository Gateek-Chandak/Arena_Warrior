﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float speed;
    public float distance;
    public float lifetime;
    public float damage;
    public LayerMask whatIsSolid;

    public GameObject moveAudio;
    public GameObject destroyAudio;

    public GameObject destroyEffect;

    void Start()
    {
        Invoke("destroyProjectile", lifetime);
        Instantiate(moveAudio, transform.position, Quaternion.identity);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<enemyManager>().takeDamage(damage);
                cameraShake.shouldShake = true;
            }
            destroyProjectile();
        }


        transform.Translate(Vector2.right *  speed * Time.deltaTime);
    }

    void destroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Instantiate(destroyAudio, transform.position, Quaternion.identity);
    }
}
