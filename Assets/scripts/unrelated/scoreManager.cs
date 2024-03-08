using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public static int score = 0;

    public Text scoreText;
    public Text highScore;
    
    void Start()
    {
        score = 0;

        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    
    void Update()
    {
        
    scoreText.text = score.ToString(); 

        //high score
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        } 
    }

    public static void addScore(int scoreAmt)
    {
        score += scoreAmt;
    }
}
