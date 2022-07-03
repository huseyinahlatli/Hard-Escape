using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;

    public void Pause()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
