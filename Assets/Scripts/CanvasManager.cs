using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField] GameObject howToPlay;
    bool state = false;

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void HowToPlay()
    {
        if(!state)
        {
            howToPlay.SetActive(true);    
            state = true; 
        }
        else if(state)
        {
            howToPlay.SetActive(false);
            state = false;
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
