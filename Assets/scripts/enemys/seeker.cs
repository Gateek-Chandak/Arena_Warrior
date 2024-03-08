using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : MonoBehaviour
{
	private Transform playerPos;
	public float speed;
	public GameObject deathEffect;

	void Start()
    {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
		transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

		if (playerPos == null)
		{
			die();
		}
    }

	void die()
	{
		Destroy(this.gameObject);
		Instantiate(deathEffect, transform.position, Quaternion.identity);
	}
}
