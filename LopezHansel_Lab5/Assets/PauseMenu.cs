using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject restartButton;
    public GameObject restartSound;
    public float tiempoVida;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        if (GameIsPaused)
        {
            pauseButton.SetActive(false);
            restartButton.SetActive(false);
        }
        else
        {
            pauseButton.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        if (GameIsPaused)
        {
            Instantiate(restartSound);
            Destroy(restartSound, tiempoVida);
            Resume();
            ScoreSystem.coinAmount = 0;
            ScoreSystem2.deathAmount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Instantiate(restartSound);
            Resume();
            ScoreSystem.coinAmount = 0;
            ScoreSystem2.deathAmount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadMenu()
    {
        RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
