using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    GameObject settingsPanel;

    public void Pause()
    {
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 0.0F;
    }

    public void Home()
    {
        Debug.Log("Welcome Scene");
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        Time.timeScale = 1.0F;
    }

    public void Reload()
    {
        Time.timeScale = 1.0F;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
