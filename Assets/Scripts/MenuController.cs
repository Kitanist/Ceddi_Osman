using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject PauseMenu;

    public GameObject SettingsMenu;

    public GameObject Panel;

    public AudioSource Theme;

    public GameObject PauseSettingsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                    Resume();
            }
                else
                {
                    Pause();
                }
        }
    }

    public void Resume()
        {
            PauseMenu.SetActive(false);
            Panel.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

    public void Pause()
        {
            PauseMenu.SetActive(true);
            Panel.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowSettings()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        gameIsPaused = true;
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetMusic(bool isMusic)
    {
        Theme.mute = !isMusic;
    }
    public void PauseSettings()
    {
        PauseMenu.SetActive(false);
        PauseSettingsMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
