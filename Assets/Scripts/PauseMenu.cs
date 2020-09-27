using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer Lowpass;

    public void Resume()
    {
        //lowpass off
        NewFadeScript.thisScript.LowpassOn = false;
        
        //pauseUI
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void StartGame()
    {
        GameManager.Instance.LoadNextScene();
    }

    void Pause()
    {
        //lowpass on
        NewFadeScript.thisScript.LowpassOn = true;

        //pauseUI
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BacktoMainMenu()
    {
        //lowpass off
        NewFadeScript.thisScript.LowpassOn = false;
        //NewFadeScript.thisScript.ResetLP();

        //GameManager.Instance.LoadMainMenu();

        StartCoroutine(LoadMainMenuDelayed());
    }

    IEnumerator LoadMainMenuDelayed()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 1f;
        GameManager.Instance.LoadMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

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
    }
}
