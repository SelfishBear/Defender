using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public Button restartButton;
    public Button quitButton;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(Restart);
        quitButton.onClick.RemoveListener(Quit);
    }
    public void Restart()
    {
        Debug.Log("Restarted");
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

