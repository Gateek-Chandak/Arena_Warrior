using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Image healthBar;
	public Text healthText;

    public static float health = 100;

	public GameObject deathEffect;
    public GameObject hitEffect;
    public GameObject hitParticles;
    public cameraShake camShake;

    void Start()
    {

    }

    void Update()
    {
        if (health >= 0)
        {
            healthBar.fillAmount = health / 100;
            healthText.text = health.ToString();
        }
        else
        {
            healthBar.fillAmount = 0;
            healthText.text = "0";
        }

		if (health <= 0)
		{
			die();
		}
    }

    public void loseHealth(float damage)
    {
        health -= damage;
        Instantiate(hitEffect, hitEffect.transform.position, Quaternion.identity);
        Instantiate(hitParticles, transform.position, Quaternion.identity);
        cameraShake.shouldShake = true;
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "lava")
		{
            health = 0f;
		}
	}

	void die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
