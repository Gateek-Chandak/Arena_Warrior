using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject pauseBG;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject exitButton;
    public AudioSource click;
    public GameObject click2;

    public bool isPaused = false;

    void Start()
    {
        pauseBG.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isPaused)
            {
                resume();
            }
            if(!isPaused)
            {
                pause();
            }
        }
    }

    void resume()
    {
        Time.timeScale = 1;
        pauseBG.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
    }

    void pause()
    {
        Time.timeScale = 0;
        pauseBG.SetActive(true);
        resumeButton.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
    }


    public void resumeButtonActivate()
    {
        Time.timeScale = 1;
        pauseBG.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        click.Play();
    }

    public void restartButtonActivate()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        click.Play();
    }

    public void quitButton()
    {
        Application.Quit();
        click.Play();
    }

    public void mMrestartButtone(int sceneToLoad)
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
        click.Play();
    }
}
