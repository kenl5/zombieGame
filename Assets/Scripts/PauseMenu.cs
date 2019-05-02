using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public bool forceModuleActive = true;

    public GameObject pauseMenuUI;
    public GameObject controlMenuUI;
    public GameObject endUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadControls ()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(true);
    }

    public void Restart ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void Back ()
    {
        pauseMenuUI.SetActive(true);
        controlMenuUI.SetActive(false);
    }
}
