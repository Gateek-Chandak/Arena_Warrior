using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject pSTR;
    public GameObject bG;

    public GameObject player;
    public playerHealth playerHealth;
    
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();

        gameOver.SetActive(false);
        pSTR.SetActive(false);
        bG.SetActive(false);
    }

    
    void Update()
    {
        if (player == null)
        {
            gameOver.SetActive(true);
            pSTR.SetActive(true);
            bG.SetActive(true);
        }
      
        if (player == null && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerHealth.health = 100f;
        }
    }
}
