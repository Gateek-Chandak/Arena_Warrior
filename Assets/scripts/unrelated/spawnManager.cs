using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] spawnPoints;

    public float timeBtwSpawns = 2;
    private float startTimBtwSpawns; 


    void Start()
    {

    }

    void Update()
    {
		if(startTimBtwSpawns > 0)
        {
            startTimBtwSpawns -= Time.deltaTime;    
        }
        if(startTimBtwSpawns <= 0)
        {
            int randPoint = Random.Range(0, spawnPoints.Length);
            int randEnemy = Random.Range(0, enemys.Length);
            Instantiate(enemys[randEnemy], spawnPoints[randPoint].position, Quaternion.identity);
            startTimBtwSpawns = timeBtwSpawns; 
        }

        if (startTimBtwSpawns <= 0.4f)
        {
            timeBtwSpawns -= 0.01f * Time.deltaTime;
        } 
    }
}
