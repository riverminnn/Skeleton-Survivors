using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenu;

    public AudioClip clickySound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(clickySound, 0.8f);
            if (GameIsPause)
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
        audioSource.PlayOneShot(clickySound, 0.8f);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void BackMainMenu()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
