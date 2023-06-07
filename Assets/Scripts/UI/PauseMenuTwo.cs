using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuTwo : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;

    private bool isPaused = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void RetryScene()
    {
        ChangeSceneByIndex(1);
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
